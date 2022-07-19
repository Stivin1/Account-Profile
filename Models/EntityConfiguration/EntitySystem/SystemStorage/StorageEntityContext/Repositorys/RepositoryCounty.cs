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
    public class RepositoryCounty : IRepositoryCountry
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public RepositoryCounty(EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Country> Append(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("Error append: argument null");

            await EntitySourceContext.Countries.AddAsync(entity);

            await EntitySourceContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Update(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Countries.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Countries.Update(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<int> Deleate(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Countries.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Countries.Remove(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<Country> GetEntity(Country entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Countries.FindAsync(entity);

            if (search != null)
            {
                return search;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<IEnumerable<Country>> GetEntitys()
        {
            return await EntitySourceContext.Countries.ToListAsync();
        }
    }
}
