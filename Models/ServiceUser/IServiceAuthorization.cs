using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceUser
{
    public interface IServiceAuthorization
    {
        public Task<int> Entrance(User user);
    }
}
