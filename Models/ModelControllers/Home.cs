using OpenSourceEntitys.Models.ModelControllers.Attributes;
using OpenSourceEntitys.Models.ModelCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class Home : IHelpersCountMessage
    {
       public ConfigRootCore ConfigRootCore { get; set; }

       public int HelpersDisplayCountMessage { get; set; }

       public int HelpersDeletedCountMessage { get; set; }
    }
}
