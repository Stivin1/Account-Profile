using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserForMessages
{
    public class ListUserForMessageSorting
    {
        public enum MessageForSorting
        {
            NameAsc,
            NameDesc,
            MiddleNameAsc,
            MiddleNameDesc,
            LastNameAsc,
            LastNameDesc,
            EmailAsc,
            EmailDesc,
            Default,
        }

        public MessageForSorting Name;

        public MessageForSorting MiddleName;

        public MessageForSorting LastName;

        public MessageForSorting Email;

        public MessageForSorting Default;

        public ListUserForMessageSorting(MessageForSorting MessageForSorting)
        {
            Default = MessageForSorting;

            Name = MessageForSorting == MessageForSorting.NameAsc ? MessageForSorting.NameDesc : MessageForSorting.NameAsc;

            MiddleName = MessageForSorting == MessageForSorting.MiddleNameAsc ? MessageForSorting.MiddleNameDesc : MessageForSorting.MiddleNameAsc;

            LastName = MessageForSorting == MessageForSorting.LastNameAsc ? MessageForSorting.LastNameDesc : MessageForSorting.LastNameAsc;

            Email = MessageForSorting == MessageForSorting.EmailAsc ? MessageForSorting.EmailDesc : MessageForSorting.EmailAsc;
        }

        public IEnumerable<AddresSent> GetListAddresSentMessageForSorting(IEnumerable<AddresSent> AddresSent, MessageForSorting MessageForSorting)
        {
            switch (MessageForSorting)
            {
                case MessageForSorting.NameAsc:
                    AddresSent = AddresSent.OrderBy(t => t.User.Profile.Name);
                    break;
                case MessageForSorting.NameDesc:
                    AddresSent = AddresSent.OrderByDescending(t => t.User.Profile.Name);
                    break;
                case MessageForSorting.MiddleNameAsc:
                    AddresSent = AddresSent.OrderBy(t => t.User.Profile.MiddleName);
                    break;
                case MessageForSorting.MiddleNameDesc:
                    AddresSent = AddresSent.OrderByDescending(t => t.User.Profile.MiddleName);
                    break;
                case MessageForSorting.LastNameAsc:
                    AddresSent = AddresSent.OrderBy(t => t.User.Profile.LastName);
                    break;
                case MessageForSorting.LastNameDesc:
                    AddresSent = AddresSent.OrderByDescending(t => t.User.Profile.LastName);
                    break;
                case MessageForSorting.EmailAsc:
                    AddresSent = AddresSent.OrderBy(t => t.User.Email);
                    break;
                case MessageForSorting.EmailDesc:
                    AddresSent = AddresSent.OrderByDescending(t => t.User.Email);
                    break;
                default: throw new Exception("Error null search element in MessageForSorting");
            }

            return AddresSent;
        }
    }
}
