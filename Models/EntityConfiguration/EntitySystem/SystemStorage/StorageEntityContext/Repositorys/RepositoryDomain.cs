﻿using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.Repositorys
{
    public class RepositoryDomain : IRepositoryDomain
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public RepositoryDomain(EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Domains> Append(Domains entity)
        {
            if (entity == null) throw new ArgumentNullException("Error append: argument null");

            await EntitySourceContext.Domains.AddAsync(entity);

            await EntitySourceContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Update(Domains entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Domains.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Domains.Update(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<int> Deleate(Domains entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Domains.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Domains.Remove(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<Domains> GetEntity(Domains entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Domains.FindAsync(entity);

            if (search != null)
            {
                return search;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<IEnumerable<Domains>> GetEntitys()
        {
            return await EntitySourceContext.Domains.ToListAsync();
        }
    }
}
