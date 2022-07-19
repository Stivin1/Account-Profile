using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceParticipant
{
    public interface IServiceParticipant
    {
        Participant SetMappgingRegParticipant(Registration registration , User user);

        public Task<int> CreateParticipant(Participant participant);

        public Task<int> UpdateParticipant(UpdateProfile UpdateProfile);
    }
}
