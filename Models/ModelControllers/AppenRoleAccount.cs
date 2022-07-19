using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.ModelControllers.ListRoles.ListRoleVeiw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class AppendRoleAccount : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<IdentityRole> IdentityRoles { get; set; }

        public IList<string> AddRole { get; set; }

        public ListRolesPagination ListRolesPagination { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
