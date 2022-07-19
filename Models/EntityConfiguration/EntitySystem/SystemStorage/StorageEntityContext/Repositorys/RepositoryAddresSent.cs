using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.Repositorys
{
    public class RepositoryAddresSent : IRepositoryAddresSent
    {
        public Task<AddresSent> Append(AddresSent entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Deleate(AddresSent entity)
        {
            throw new NotImplementedException();
        }

        public Task<AddresSent> GetEntity(AddresSent entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddresSent>> GetEntitys()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(AddresSent entity)
        {
            throw new NotImplementedException();
        }
    }
}
