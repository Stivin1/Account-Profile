using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceParticipant.ExtensionMethods
{
    public static class EextensionAge
    {
        public static int GetParticipantAge(this string dateage)
        {
            DateTime dateTime;

            DateTime dateTime1 = DateTime.Now;

            DateTime.TryParse(dateage, out dateTime);

            int age = dateTime1.Year - dateTime.Year;

            if(dateTime1.Month < dateTime.Month || (dateTime1.Month == dateTime.Month || dateTime1.Day < dateTime.Day))
            {
                age--;
            }

            return age;
        }
    }
}
