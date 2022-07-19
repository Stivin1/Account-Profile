using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public interface IHelpersCountMessage
    {
        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
