
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.Repositorys
{
    public class RepositoryGroups : IRepositoryGroups
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public RepositoryGroups(EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Groups> Append(Groups entity)
        {
            if (entity == null) throw new ArgumentNullException("Error append: argument null");

            await EntitySourceContext.Groups.AddAsync(entity);

            await EntitySourceContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Update(Groups entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Groups.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Groups.Update(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<int> Deleate(Groups entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Groups.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Groups.Remove(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<Groups> GetEntity(Groups entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Groups.FindAsync(entity);

            if (search != null)
            {
                return search;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<IEnumerable<Groups>> GetEntitys()
        {
            return await EntitySourceContext.Groups.ToListAsync();
        }
    }
}
