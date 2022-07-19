using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages
{
    public class ListUserMessageSorting
    {
        public enum MessageSorting
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

        public MessageSorting Name;

        public MessageSorting MiddleName;

        public MessageSorting LastName;

        public MessageSorting Email;

        public MessageSorting Default;

        public ListUserMessageSorting(MessageSorting MessageSorting)
        {
            Default = MessageSorting;

            Name = MessageSorting == MessageSorting.NameAsc ? MessageSorting.NameDesc : MessageSorting.NameAsc;

            MiddleName = MessageSorting == MessageSorting.MiddleNameAsc ? MessageSorting.MiddleNameDesc : MessageSorting.MiddleNameAsc;

            LastName = MessageSorting == MessageSorting.LastNameAsc ? MessageSorting.LastNameDesc : MessageSorting.LastNameAsc;

            Email = MessageSorting == MessageSorting.EmailAsc ? MessageSorting.EmailDesc : MessageSorting.EmailAsc;
        }

        public IEnumerable<Participant> GetListParticipantMessageSorting(IEnumerable<Participant> Participant, MessageSorting MessageSorting)
        {
            switch (MessageSorting)
            {
                case MessageSorting.NameAsc:
                    Participant = Participant.OrderBy(t => t.Name);
                    break;
                case MessageSorting.NameDesc:
                    Participant = Participant.OrderByDescending(t => t.Name);
                    break;
                case MessageSorting.MiddleNameAsc:
                    Participant = Participant.OrderBy(t => t.MiddleName);
                    break;
                case MessageSorting.MiddleNameDesc:
                    Participant = Participant.OrderByDescending(t => t.MiddleName);
                    break;
                case MessageSorting.LastNameAsc:
                    Participant = Participant.OrderBy(t => t.LastName);
                    break;
                case MessageSorting.LastNameDesc:
                    Participant = Participant.OrderByDescending(t => t.LastName);
                    break;
                case MessageSorting.EmailAsc:
                    Participant = Participant.OrderBy(t => t.User.Email);
                    break;
                case MessageSorting.EmailDesc:
                    Participant = Participant.OrderByDescending(t => t.User.Email);
                    break;
                default: throw new Exception("Error null search element in MessageSorting");
            }

            return Participant;
        }
    }
}
