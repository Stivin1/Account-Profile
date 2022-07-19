using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService
{
    public class ListParticipantSorting
    {
        public enum Sorting
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

        public Sorting Name;

        public Sorting MiddleName;

        public Sorting LastName;

        public Sorting Email;

        public Sorting Default;

        public ListParticipantSorting(Sorting Sorting)
        {
            Default = Sorting;

            Name = Sorting == Sorting.NameAsc ? Sorting.NameDesc : Sorting.NameAsc;

            MiddleName = Sorting == Sorting.MiddleNameAsc ? Sorting.MiddleNameDesc : Sorting.MiddleNameAsc;

            LastName = Sorting == Sorting.LastNameAsc ? Sorting.LastNameDesc : Sorting.LastNameAsc;

            Email = Sorting == Sorting.EmailAsc ? Sorting.EmailDesc : Sorting.EmailAsc;
        }

        public IEnumerable<Participant> GetListParticipantSorting(IEnumerable<Participant> Participant, Sorting Sorting)
        {
            switch(Sorting)
            {
                case Sorting.NameAsc:
                    Participant = Participant.OrderBy(t => t.Name);
                    break;
                case Sorting.NameDesc:
                    Participant = Participant.OrderByDescending(t => t.Name);
                    break;
                case Sorting.MiddleNameAsc:
                    Participant = Participant.OrderBy(t => t.MiddleName);
                    break;
                case Sorting.MiddleNameDesc:
                    Participant = Participant.OrderByDescending(t => t.MiddleName);
                    break;
                case Sorting.LastNameAsc:
                    Participant = Participant.OrderBy(t => t.LastName);
                    break;
                case Sorting.LastNameDesc:
                    Participant = Participant.OrderByDescending(t => t.LastName);
                    break;
                case Sorting.EmailAsc:
                    Participant = Participant.OrderBy(t => t.User.Email);
                    break;
                case Sorting.EmailDesc:
                    Participant = Participant.OrderByDescending(t => t.User.Email);
                    break;
                default: throw new Exception("Error null search element in sorting");
            }

            return Participant;
        }
    }
}
