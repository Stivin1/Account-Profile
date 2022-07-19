using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages
{
    public class ListUserMessageFiltering
    {
        public IEnumerable<Participant> Participant { get; set; }

        public ListUserMessageFiltering(IEnumerable<Participant> Participant)
        {
            this.Participant = Participant;
        }

        public IEnumerable<Participant> ListUsersGetFiltering(string MiddleName, string Name, string LastName, string Email)
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

            return Participant;
        }
    }
}
