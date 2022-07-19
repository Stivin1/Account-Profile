using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class AppendGroupAccount : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public IEnumerable<Groups> Groups { get; set; }

        public IEnumerable<Groups> UserListGroups { get; set; }

        public ListGroupsPagination ListGroupsUsersPagination { get; set; }

        public ListGroupsPagination ListGroupsPagination { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
