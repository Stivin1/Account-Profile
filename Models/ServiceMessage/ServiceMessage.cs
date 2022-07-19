using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceMessage
{
    public class ServiceMessage : IServiceMessage
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public ServiceMessage
            (
            EntitySourceContext EntitySourceContext
            )
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<IEnumerable<Participant>> GetListSendUser()
        {
            var usemessage = await EntitySourceContext.Participants.Include(t => t.User).ToListAsync();

            return usemessage;
        }

        public async Task<int> MessageSent(string Theme, string text, string UserSenderId, string UserRecipientId)
        {
            var theme = await GetFromingThemeMessage(Theme);

            var message = await GetFromingMessage(theme, text);

            var address = await GetFromingAddressMessage(message, UserSenderId, UserRecipientId);

            var setting = await GetFromingSettingMessage(address);

            if (theme == null || message == null || address == null || setting == null)
                throw new ArgumentNullException("Erro null argument in method MessageSent { theme, message, address }");

            await EntitySourceContext.Themes.AddAsync(theme);

            await EntitySourceContext.Messages.AddAsync(message);

            await EntitySourceContext.addresSents.AddAsync(address);

            await EntitySourceContext.MessageSettings.AddAsync(setting);

            await EntitySourceContext.SaveChangesAsync();

            return Task.FromResult(1).Result;

        }

        public async Task<Theme> GetFromingThemeMessage(string Theme)
        {
            Theme Themes = new Theme
            {
                Name = Theme
            };

            return await Task.FromResult(Themes);
        }

        public async Task<Message> GetFromingMessage(Theme theme, string text)
        {
            Message Messages = new Message
            {
                Theme = theme,
                MessageText = text,
                DateCreate = DateTime.Now.ToString(),
                IsHidden = false,
                IsRead = false
            };

            return await Task.FromResult(Messages);
        }

        public async Task<AddresSent> GetFromingAddressMessage(Message message, string UserSenderId, string UserRecipientId)
        {
            if (string.IsNullOrEmpty(UserSenderId) || string.IsNullOrEmpty(UserRecipientId))
                throw new ArgumentNullException("Error null theme in GetFromingThemeMessage");

            AddresSent AddresSents = new AddresSent
            {
                Message = message,
                UserId = UserSenderId,
                RecipientId = UserRecipientId,
                DateCreate = DateTime.Now.ToString()
            };

            return await Task.FromResult(AddresSents);
        }

        public async Task<IEnumerable<AddresSent>> GetMessageSentsForUsers(string UserId)
        {
            var messagedonor = await EntitySourceContext.addresSents
            .Include(t => t.User)
            .ThenInclude(t => t.Profile)
            .Include(t => t.Message)
            .ThenInclude(t => t.MessageSettings)
            .Where(t => t.UserId == UserId
            && t.Message.MessageSettings.MessageDonorIsHidden == false)
            .OrderByDescending(t => t.Message.DateCreate).ToListAsync();

            var messagerecipient = await EntitySourceContext.addresSents
            .Include(t => t.User)
            .ThenInclude(t => t.Profile)
            .Include(t => t.Message)
            .ThenInclude(t => t.MessageSettings)
            .Where(t => t.RecipientId == UserId
            && t.Message.MessageSettings.MessageRecipientIsHidden == false)
            .OrderByDescending(t => t.Message.DateCreate).ToListAsync();

            var usermessage = messagedonor.Union(messagerecipient).OrderByDescending(t => t.MessageId);

            return usermessage;
        }

        public async Task<AddresSent> GetReadMessageAsync(string UserId, int? MessageId)
        {
            try
            {
                var messageread = await SetMessageBoolReadAsync(UserId, MessageId);

                if (messageread.AddresSent.RecipientId == UserId)
                {
                    messageread.IsRead = true;

                    await EntitySourceContext.SaveChangesAsync();
                }

                return await GetMessageAsync(MessageId);
            }
            catch (Exception mes)
            {
                throw new Exception(mes.Message);
            }
        }

        private async Task<AddresSent> GetMessageAsync(int? MessageId)
        {
            if (MessageId == 0 || MessageId == null) throw new Exception("Error GetMessageAsync = null or 0");

            var message = await EntitySourceContext.addresSents.Include(t => t.Message)
                .ThenInclude(t => t.Theme).FirstOrDefaultAsync(t => t.MessageId == MessageId);


            return message;
        }

        private async Task<Message> SetMessageBoolReadAsync(string UserId, int? MessageId)
        {
            var message = await EntitySourceContext.Messages.Include(t => t.AddresSent)
                .FirstOrDefaultAsync(t => t.id == MessageId);

            return message;

        }

        public Task<AddresSent> GetReplyMessage(int? MessageId)
        {
            var address = EntitySourceContext.addresSents.FirstOrDefault(t => t.MessageId == MessageId);

            if (address == null)
                throw new ArgumentNullException("Error address null in method GetRiplyMessage");


            return Task.FromResult(address);
        }

        public async Task<MessageSettings> GetFromingSettingMessage(AddresSent messagesetting)
        {

            MessageSettings AddresSents = new MessageSettings
            {
                Message = messagesetting.Message,
                UserId = messagesetting.UserId,
                UserRecipientId = messagesetting.RecipientId,
                MessageDonorIsHidden = false,
                MessageRecipientIsHidden = false
            };

            return await Task.FromResult(AddresSents);
        }

        public async Task<int> BasketMessage(int OperationId, string UserId, int? Messageid)
        {
            var MessageDonorSettings = await EntitySourceContext?.MessageSettings?.FirstOrDefaultAsync(t => t.Message.id == Messageid && t.UserId == UserId);

            var MessageRecipientSettings = await EntitySourceContext?.MessageSettings?.FirstOrDefaultAsync(t => t.Message.id == Messageid && t.UserRecipientId == UserId);

            if (OperationId == 1)
            {
                if (!string.IsNullOrEmpty(MessageDonorSettings?.UserId))
                {
                    if (MessageDonorSettings?.UserId == UserId)
                    {
                        MessageDonorSettings.MessageDonorIsHidden = true;

                        EntitySourceContext.Update(MessageDonorSettings);
                    }
                }

                if (!string.IsNullOrEmpty(MessageRecipientSettings?.UserId))
                {
                    if (MessageRecipientSettings?.UserRecipientId == UserId)
                    {
                        MessageRecipientSettings.MessageRecipientIsHidden = true;

                        EntitySourceContext.Update(MessageRecipientSettings);
                    }
                }

                if (!string.IsNullOrEmpty(MessageDonorSettings?.UserId) && !string.IsNullOrEmpty(MessageRecipientSettings?.UserId))
                {
                    if (MessageDonorSettings?.UserId == UserId && MessageRecipientSettings?.UserId == UserId)
                    {
                        MessageDonorSettings.MessageDonorIsHidden = true;

                        MessageDonorSettings.MessageRecipientIsHidden = true;

                        EntitySourceContext.Update(MessageDonorSettings);
                    }
                }


                await EntitySourceContext.SaveChangesAsync();
            }

            return Task.FromResult(1).Result;
        }

        public async Task<int> RecoverMessage(string UserId, int? Messageid)
        {
            var MessageDonorSettings = await EntitySourceContext?.MessageSettings?.FirstOrDefaultAsync(t => t.Message.id == Messageid && t.UserId == UserId);

            var MessageRecipientSettings = await EntitySourceContext?.MessageSettings?.FirstOrDefaultAsync(t => t.Message.id == Messageid && t.UserRecipientId == UserId);

            if (!string.IsNullOrEmpty(MessageDonorSettings?.UserId))
            {
                if (MessageDonorSettings?.UserId == UserId)
                {
                    MessageDonorSettings.MessageDonorIsHidden = false;

                    EntitySourceContext.Update(MessageDonorSettings);
                }
            }

            if (!string.IsNullOrEmpty(MessageRecipientSettings?.UserId))
            {
                if (MessageRecipientSettings?.UserRecipientId == UserId)
                {
                    MessageRecipientSettings.MessageRecipientIsHidden = false;

                    EntitySourceContext.Update(MessageRecipientSettings);
                }
            }

            if (!string.IsNullOrEmpty(MessageDonorSettings?.UserId) && !string.IsNullOrEmpty(MessageRecipientSettings?.UserId))
            {
                if (MessageDonorSettings?.UserId == UserId && MessageRecipientSettings?.UserId == UserId)
                {
                    MessageDonorSettings.MessageDonorIsHidden = false;

                    MessageDonorSettings.MessageRecipientIsHidden = false;

                    EntitySourceContext.Update(MessageDonorSettings);
                }
            }

            await EntitySourceContext.SaveChangesAsync();

            return Task.FromResult(1).Result;
        }

        public async Task<IEnumerable<AddresSent>> GetShowMessageBasket(string UserId)
        {
            var messagedonor = await EntitySourceContext.addresSents
            .Include(t => t.User)
            .ThenInclude(t => t.Profile)
            .Include(t => t.Message)
            .ThenInclude(t => t.MessageSettings)
            .Where(t => t.UserId == UserId
            && t.Message.MessageSettings.MessageDonorIsHidden == true)
            .OrderByDescending(t => t.Message.DateCreate).ToListAsync();

            var messagerecipient = await EntitySourceContext.addresSents
            .Include(t => t.User)
            .ThenInclude(t => t.Profile)
            .Include(t => t.Message)
            .ThenInclude(t => t.MessageSettings)
            .Where(t => t.RecipientId == UserId
            && t.Message.MessageSettings.MessageRecipientIsHidden == true)
            .OrderByDescending(t => t.Message.DateCreate).ToListAsync();

            var usermessage = messagedonor.Union(messagerecipient).OrderByDescending(t => t.MessageId);

            return usermessage;
        }
    }
}
