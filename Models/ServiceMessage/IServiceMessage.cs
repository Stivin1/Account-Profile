using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceMessage
{
    public interface IServiceMessage
    {
        public Task<IEnumerable<Participant>> GetListSendUser();

        public Task<int> MessageSent(string Theme, string text, string UserSenderId, string UserRecipientId);

        public Task<Theme> GetFromingThemeMessage(string Theme);

        public Task<Message> GetFromingMessage(Theme theme, string text);

        public Task<AddresSent> GetFromingAddressMessage(Message message , string UserSenderId, string UserRecipientId);

        public Task<MessageSettings> GetFromingSettingMessage(AddresSent messagesetting);

        public Task<IEnumerable<AddresSent>> GetMessageSentsForUsers(string UserId);

        public Task<AddresSent> GetReadMessageAsync(string UserId, int? MessageId);

        public Task<AddresSent> GetReplyMessage(int? MessageId);

        public Task<int> BasketMessage(int OperationId, string UserId, int? Messageid);

        public Task<int> RecoverMessage(string UserId, int? Messageid);

        public Task<IEnumerable<AddresSent>> GetShowMessageBasket(string UserId);
    }
}
