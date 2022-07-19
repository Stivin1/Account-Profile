using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserForMessages
{
    public class ListUserForMessageFiltering
    {
        public IEnumerable<AddresSent> AddresSent { get; set; }

        public ListUserForMessageFiltering(IEnumerable<AddresSent> AddresSent)
        {
            this.AddresSent = AddresSent;
        }

        public IEnumerable<AddresSent> ListUsersGetFiltering(string MiddleName, string Name, string LastName, string Email)
        {
            if (!string.IsNullOrEmpty(MiddleName))
            {
                AddresSent = AddresSent.Where(t => t.User.Profile.MiddleName.Contains(MiddleName));
            }

            if (!string.IsNullOrEmpty(Name))
            {
                AddresSent = AddresSent.Where(t => t.User.Profile.Name.Contains(Name));
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                AddresSent = AddresSent.Where(t => t.User.Profile.LastName.Contains(LastName));
            }

            if (!string.IsNullOrEmpty(Email))
            {
                AddresSent = AddresSent.Where(t => t.User.Email.Contains(Email));
            }

            return AddresSent;
        }
    }
}
