using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService
{
    public interface IListParticipantService
    {
        Task<IEnumerable<Participant>> GetListUserService();
    }
}
