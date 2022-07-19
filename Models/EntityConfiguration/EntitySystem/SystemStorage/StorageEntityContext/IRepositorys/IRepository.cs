using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys
{
    public interface IRepository<T> where T: class
    {
        public Task<T> Append(T entity);

        public Task<int> Update(T entity);

        public Task<int> Deleate(T entity);

        public Task<T> GetEntity(T entity);

        public Task<IEnumerable<T>> GetEntitys();
    }
}
