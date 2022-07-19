using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ServiceParticipant.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceParticipant
{
    public class ServiceParticipant : IServiceParticipant
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        public ServiceParticipant
            (
            EntitySourceContext EntitySourceContext,
            IUnitOfWork UnitOfWork
            )
        {
            this.EntitySourceContext = EntitySourceContext;
            this.UnitOfWork = UnitOfWork;
        }

        public Participant SetMappgingRegParticipant(Registration registration, User user)
        {
            Participant participant = new Participant
            {
                Name = registration.Name,
                MiddleName = registration.MiddleName,
                LastName = registration.LastName,
                DateAge = registration.DateAge,
                DateChanges = DateTime.Now.ToString(),
                PolId = registration.PolId,
                UserId = user.Id
            };

            return participant;
        }

        public async Task<int> UpdateParticipant(UpdateProfile UpdateProfile)
        {
            var searchpart = await EntitySourceContext.Participants.FirstOrDefaultAsync(t => t.UserId == UpdateProfile.UserId);

            if (searchpart == null)
                throw new ArgumentNullException("Error UpdateParticipant in searchpart argument null");

            searchpart.Name = UpdateProfile.Name;
            searchpart.MiddleName = UpdateProfile.MiddleName;
            searchpart.LastName = UpdateProfile.LastName;
            searchpart.DateAge = UpdateProfile.DateAge;
            searchpart.DateChanges = DateTime.Now.ToString();
            searchpart.PolId = UpdateProfile.PolId;
            searchpart.User.CountryId = UpdateProfile.CountryId;
            searchpart.User.Year = EextensionAge.GetParticipantAge(UpdateProfile.DateAge);

            await UnitOfWork.RepositoryParticipant.Update(searchpart);

            return 1;
        }

        public async Task<int> CreateParticipant(Participant participant)
        {
            if (participant == null) throw new ArgumentNullException("Error in CreateParticipant argument null");

            await UnitOfWork.RepositoryParticipant.Append(participant);

            return 1;

        }
    }
}
