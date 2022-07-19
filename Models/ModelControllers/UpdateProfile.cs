using Microsoft.AspNetCore.Mvc.Rendering;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class UpdateProfile : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public Participant Participant { get; set; } 

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

        public int PolId { get; set; }

        public SelectList SelectPol { get; set; }

        public int CountryId { get; set; }

        public SelectList SelectCountry { get; set; }

        public int DomenId { get; set; }

        public SelectList SelectDomen { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
