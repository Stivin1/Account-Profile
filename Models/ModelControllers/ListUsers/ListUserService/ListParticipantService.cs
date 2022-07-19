using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService
{
    public class ListParticipantService : IListParticipantService
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        public ListParticipantService
            (
            EntitySourceContext EntitySourceContext,
            IUnitOfWork UnitOfWork
            )
        {
            this.EntitySourceContext = EntitySourceContext;
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<Participant>> GetListUserService()
        {
            var search = await EntitySourceContext.Participants.Include(t => t.User).ToListAsync();

            return search; 
        }
    }
}
