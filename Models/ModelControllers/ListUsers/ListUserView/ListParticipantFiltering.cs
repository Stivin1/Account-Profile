using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService
{
    public class ListParticipantFiltering
    {
        public IEnumerable<Participant> Participant { get; set; }

        public ListParticipantFiltering(IEnumerable<Participant> Participant)
        {
            this.Participant = Participant;
        }

        public IEnumerable<Participant> ListUsersGetFiltering(string MiddleName, string Name, string LastName, string Email, string UserName)
        {
            if (!string.IsNullOrEmpty(MiddleName))
            {
                Participant = Participant.Where(t => t.MiddleName.Contains(MiddleName));
            }

            if (!string.IsNullOrEmpty(Name))
            {
                Participant = Participant.Where(t => t.Name.Contains(Name));
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                Participant = Participant.Where(t => t.LastName.Contains(LastName));
            }

            if (!string.IsNullOrEmpty(Email))
            {
                Participant = Participant.Where(t => t.User.Email.Contains(Email));
            }

            if (!string.IsNullOrEmpty(UserName))
            {
                Participant = Participant.Where(t => t.User.UserName.Contains(UserName));
            }

            return Participant;
        }
    }
}
