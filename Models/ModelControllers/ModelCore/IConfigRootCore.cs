using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ModelCore
{
    public interface IConfigRootCore
    {
        public User UserCore { get; set; }

        public Participant ParticipantCore { get; set; }

        public ScopeAvailability ScopeAvailabilityCore { get; set; }
    }
}
