using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class UpdateAccount : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Количество символов должено содержать от 2 до 20")]
        public string UserName { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
