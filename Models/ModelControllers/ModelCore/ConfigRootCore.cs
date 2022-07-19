using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelCore
{
    public class ConfigRootCore : ScopeAvailability
    {
        public User UserCore { get; set; }

        public Participant ParticipantCore { get; set; }
    }
}
