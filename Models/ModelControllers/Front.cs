using OpenSourceEntitys.Models.ModelControllers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class Front
    {
        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Количество символов должено содержать от 5 до 20")]
        [AttEmail(new string[] {"@bk.ru","@bk.com", "@mail.ru", "@mail.com" }, ErrorMessage = "Не корректно указан адрес электронной почты. Выберите следующие домены @bk.ru,@bk.com,@mail.ru,@mail.com ")]
        public string Email { get; set; }

        public int ParticipantCount { get; set; }

        public int GroupCount { get; set; }
    }
}
