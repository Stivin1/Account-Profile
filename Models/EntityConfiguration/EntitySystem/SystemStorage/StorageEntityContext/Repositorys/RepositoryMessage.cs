
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.Repositorys
{
    public class RepositoryMessage : IRepositoryMessage
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public RepositoryMessage(EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Message> Append(Message entity)
        {
            if (entity == null) throw new ArgumentNullException("Error append: argument null");

            await EntitySourceContext.Messages.AddAsync(entity);

            await EntitySourceContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Update(Message entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Messages.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Messages.Update(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<int> Deleate(Message entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Messages.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Messages.Remove(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<Message> GetEntity(Message entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Messages.FindAsync(entity);

            if (search != null)
            {
                return search;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<IEnumerable<Message>> GetEntitys()
        {
            return await EntitySourceContext.Messages.ToListAsync();
        }
    }
}