using Microsoft.AspNetCore.Mvc.Rendering;
using OpenSourceEntitys.Models.ModelControllers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class Registration
    {
        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = "Количество символов должено содержать от 5 до 20")]
        [AttEmail(new string[] { "@bk.ru", "@bk.com", "@mail.ru", "@mail.com" }, ErrorMessage = "Не корректно указан адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Количество символов должено содержать от 2 до 20")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Количество символов должено содержать от 2 до 30")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Количество символов должено содержать от 2 до 20")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Количество символов должено содержать от 2 до 20")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Количество символов должено содержать от 2 до 20")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не заполнено")]
        public string DateAge { get; set; }

        [AttConsentProvisionPersonalData]
        public bool ConsentProvisionPersonalData { get; set; }

        public int PolId { get; set; }

        public SelectList SelectPol { get; set; }

        public int CountryId { get; set; }

        public SelectList SelectCountry { get; set; }

        public int DomenId { get; set; }

        public SelectList SelectDomen { get; set; }
    }
}
