using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class ListUsersGroups : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string DateCreate { get; set; }

        public IEnumerable<UsersGroupsView> UsersGroupsView { get; set; }

        public ListUsersGroupsFiltering ListUsersGroupsFiltering { get; set; }

        public ListUsersGroupsPagination ListUsersGroupsPagination { get; set; }

        public ListUsersGroupsSorting ListUsersGroupsSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
