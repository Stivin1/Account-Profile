using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups
{
    public class UsersGroupsView
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Count { get; set; }

        public string DateCreate { get; set; }
    }
}
