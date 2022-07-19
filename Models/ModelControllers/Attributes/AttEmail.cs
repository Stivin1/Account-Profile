using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.Attributes
{
    public class AttEmail : ValidationAttribute
    {
        string[] domain;

        public AttEmail(string[] domain)
        {
            this.domain = domain;
        }

        public override bool IsValid(object value)
        {
            if(value is string s)
            {
                for (int i = 0; i < domain.Length; i++)
                {
                    if (s.Contains(domain[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
