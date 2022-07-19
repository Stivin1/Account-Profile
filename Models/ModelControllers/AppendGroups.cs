using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUserView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class AppendGroups : IHelpersCountMessage
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        public string GroupName { get; set; }

        public IEnumerable<Groups> Groups { get; set; }

        public ListGroupsPagination ListGroupsPagination { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }

    }
}
