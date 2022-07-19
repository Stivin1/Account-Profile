using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.Attributes
{
    public class AttConsentProvisionPersonalData : ValidationAttribute
    {
        public AttConsentProvisionPersonalData()
        {
            ErrorMessage = "Ошибка ! Вы не подтвердили согласие на обработку ваших персональных данных ";
        }

        public override bool IsValid(object value)
        {
            if(value is bool p)
            {
                if (p == false) return false;
            }

            return true;
        }
    }
}
