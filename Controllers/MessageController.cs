using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserForMessages;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages;
using OpenSourceEntitys.Models.ServiceMessage;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;
using static OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserForMessages.ListUserForMessageSorting;
using static OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages.ListUserMessageSorting;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;

        private UserManager<User> UserManager { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private IServiceMessage IServiceMessage { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public MessageController(
            ILogger<MessageController> logger,
            UserManager<User> UserManager,
            EntitySourceContext EntitySourceContext,
            IServiceMessage IServiceMessage,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.IServiceMessage = IServiceMessage;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string UserId, string MiddleName, string Name, string LastName, string Email, int page = 1, MessageSorting Sorting = MessageSorting.NameAsc)
        {
            var listuser = await IServiceMessage.GetListSendUser();

            ListUserMessageFiltering ListUserMessageFiltering = new ListUserMessageFiltering(listuser);

            var filtering = ListUserMessageFiltering.ListUsersGetFiltering(MiddleName, Name, LastName, Email);

            ListUserMessageSorting ListParticipantSorting = new ListUserMessageSorting(Sorting);

            var sorting = ListParticipantSorting.GetListParticipantMessageSorting(filtering, Sorting);

            ListUserMessagePagination ListUsersPagination = new ListUserMessagePagination(page, 7, listuser.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Sendingamessage);

            return View(new ListMessage
            {
                MiddleName = MiddleName,
                Name = Name,
                LastName = LastName,
                UserId = UserId,
                Participants = sorting.Skip((page - 1) * 7).Take(7),
                ListUserMessageSorting = ListParticipantSorting,
                ListUserMessagePagination = ListUsersPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()

            });
        }

        [HttpGet]
        public async Task<IActionResult> MessageSend(string UserSenderId, string UserRecipientId)
        {
            if(!string.IsNullOrEmpty(UserSenderId) && !string.IsNullOrEmpty(UserRecipientId))
            {
                var UserSenders = await UserManager.FindByIdAsync(UserSenderId);

                var UserRecipient = await UserManager.FindByIdAsync(UserRecipientId);

                await UnitLogOfWork.RepositoryLogging.InsertLog(UserSenderId, InformationLoggingEnum.Gettingpagedataforsendingamessage);

                return View(new MessageSend
                {
                    UserId = UserSenderId,
                    UserName = UserSenders.UserName,
                    UserRecipientId = UserRecipientId,
                    UserRecipientName = UserRecipient.UserName,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == UserSenderId || t.RecipientId == UserSenderId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                    .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                    .Where(t => (t.UserId == UserSenderId && t.MessageDonorIsHidden == true)
                    || (t.UserRecipientId == UserSenderId && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MessageSend(MessageSend MessageSend)
        {
            if(ModelState.IsValid)
            {
               await  IServiceMessage.MessageSent(
                   MessageSend.Theme,
                   MessageSend.Text,
                   MessageSend.UserId,
                   MessageSend.UserRecipientId
                   );
            }

            await UnitLogOfWork.RepositoryLogging.InsertLog(MessageSend.UserId, InformationLoggingEnum.Sendingamessage);

            return View(new MessageSend
            {
                UserId = MessageSend.UserId,
                UserName = MessageSend.UserName,
                UserRecipientId = MessageSend.UserRecipientId,
                UserRecipientName = MessageSend.UserName,
                Theme = MessageSend.Theme,
                Text = MessageSend.Text,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == MessageSend.UserId || t.RecipientId == MessageSend.UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == MessageSend.UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == MessageSend.UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        } 

        [HttpGet]
        public async Task<IActionResult> MessageForUsers(string UserId, string MiddleName, string Name, string LastName, string Email, int? MessageId, int OperationBasket = 0, int page = 1, MessageForSorting Sorting = MessageForSorting.NameAsc)
        {

            if(MessageId != null)
                await IServiceMessage.BasketMessage(OperationBasket, UserId, MessageId);

            var listuser = await IServiceMessage.GetMessageSentsForUsers(UserId);

            ListUserForMessageFiltering ListUserMessageFiltering = new ListUserForMessageFiltering(listuser);

            var filtering = ListUserMessageFiltering.ListUsersGetFiltering(MiddleName, Name, LastName, Email);

            ListUserForMessageSorting ListUserForMessageSorting = new ListUserForMessageSorting(Sorting);

            var sorting = ListUserForMessageSorting.GetListAddresSentMessageForSorting(filtering, Sorting);

            ListUserForMessagePagination ListUserForMessagePagination = new ListUserForMessagePagination(page, 7, listuser.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Sendingamessage);

            return View(new MessageForUsers
            {
                MiddleName = MiddleName,
                Name = Name,
                LastName = LastName,
                UserId = UserId,
                Email = Email,
                AddresSents  = sorting.Skip((page - 1) * 7).Take(7).OrderByDescending(t => t.id),
                ListUserForMessageSorting = ListUserForMessageSorting,
                ListUserForMessagePagination = ListUserForMessagePagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()

            });
        }

        [HttpGet]
        public async Task<IActionResult> MessageRead(string UserId, int MessageId)
        {
            var message = await IServiceMessage.GetReadMessageAsync(UserId,MessageId);

            var donor = await UserManager.FindByIdAsync(message.UserId);

            var recip = await UserManager.FindByIdAsync(message.RecipientId);

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingmessageviewformdata);

            return View(new MessageRead
            {
                MessageReadId = MessageId,
                UserId = UserId,
                RecipientId = message.RecipientId,
                SenderName = donor.Email,
                RecipientName = recip.Email,
                Theme = message.Message.Theme.Name,
                Text = message.Message.MessageText,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }

        [HttpGet]
        public async Task<IActionResult> ReplyMessage(int? MessageId)
        {
            if (MessageId != null)
            {
                var address = IServiceMessage.GetReplyMessage(MessageId);

                var UserSenders = await UserManager.FindByIdAsync(address.Result.UserId);
                var UserRecipient = await UserManager.FindByIdAsync(address.Result.RecipientId);

                await UnitLogOfWork.RepositoryLogging.InsertLog(address.Result.UserId, InformationLoggingEnum.Gettingmessageviewformdata);

                return View(new ReplyMessage
                {
                    UserId = UserSenders.Id,
                    UserName = UserSenders.UserName,
                    UserRecipientId = UserRecipient.Id,
                    UserRecipientName = UserRecipient.UserName,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == UserSenders.Id || t.RecipientId == UserSenders.Id).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserSenders.Id && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserSenders.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReplyMessage(ReplyMessage replyMessage)
        {
            if (ModelState.IsValid)
            {
                await IServiceMessage.MessageSent(
                    replyMessage.Theme,
                    replyMessage.Text,
                    replyMessage.UserId,
                    replyMessage.UserRecipientId
                    );
            }

            await UnitLogOfWork.RepositoryLogging.InsertLog(replyMessage.UserId, InformationLoggingEnum.Sendingamessage);

            return View(new ReplyMessage
            {
                UserId = replyMessage.UserId,
                UserName = replyMessage.UserName,
                UserRecipientId = replyMessage.UserRecipientId,
                UserRecipientName = replyMessage.UserRecipientName,
                Theme = replyMessage.Theme,
                Text = replyMessage.Text,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == replyMessage.UserId || t.RecipientId == replyMessage.UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == replyMessage.UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == replyMessage.UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> MessageDeleted(string UserId, string MiddleName, string Name, string LastName, string Email, int page = 1, MessageForSorting Sorting = MessageForSorting.NameAsc)
        {
            var listuser = await IServiceMessage.GetShowMessageBasket(UserId);

            ListUserForMessageFiltering ListUserMessageFiltering = new ListUserForMessageFiltering(listuser);

            var filtering = ListUserMessageFiltering.ListUsersGetFiltering(MiddleName, Name, LastName, Email);

            ListUserForMessageSorting ListUserForMessageSorting = new ListUserForMessageSorting(Sorting);

            var sorting = ListUserForMessageSorting.GetListAddresSentMessageForSorting(filtering, Sorting);

            ListUserForMessagePagination ListUserForMessagePagination = new ListUserForMessagePagination(page, 7, listuser.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.RetrievingDeletedMessagesPageData);

            return View(new MessageDeleted
            {
                MiddleName = MiddleName,
                Name = Name,
                LastName = LastName,
                UserId = UserId,
                Email = Email,
                AddresSents = sorting.Skip((page - 1) * 7).Take(7).OrderByDescending(t => t.id),
                ListUserForMessageSorting = ListUserForMessageSorting,
                ListUserForMessagePagination = ListUserForMessagePagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()

            });
        }

        [HttpGet]
        public async Task<IActionResult> RecoverMessage(string UserId, int? MessageId)
        {
            await IServiceMessage.RecoverMessage(UserId, MessageId);

            return RedirectToAction("MessageDeleted", "Message", new { UserId = UserId });
            
        }
    }
}