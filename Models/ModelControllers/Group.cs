using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class Group : IHelpersCountMessage
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Наименование группы не заполнено")]
        public string GroupName { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
