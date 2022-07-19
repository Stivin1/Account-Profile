using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.ModelControllers.ListRoles.ListRoleVeiw;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class Role : IHelpersCountMessage
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Наименование роли не заполнено")]
        public string RoleName { get; set; }

        public ListRolesPagination ListRolesPagination { get; set; }

        public IEnumerable<IdentityRole> IdentityRoles { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
