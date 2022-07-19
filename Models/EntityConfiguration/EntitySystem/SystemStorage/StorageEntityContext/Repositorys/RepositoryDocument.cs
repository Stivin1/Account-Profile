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
    public class RepositoryDocument : IRepositoryDocument
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public RepositoryDocument(EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Document> Append(Document entity)
        {
            if (entity == null) throw new ArgumentNullException("Error append: argument null");

            await EntitySourceContext.Documents.AddAsync(entity);

            await EntitySourceContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Update(Document entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Documents.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Documents.Update(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<int> Deleate(Document entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Documents.FindAsync(entity);

            if (search != null)
            {
                EntitySourceContext.Documents.Remove(entity);

                await EntitySourceContext.SaveChangesAsync();

                return 1;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<Document> GetEntity(Document entity)
        {
            if (entity == null) throw new ArgumentNullException("Error deleate: argument null");

            var search = await EntitySourceContext.Documents.FindAsync(entity);

            if (search != null)
            {
                return search;
            }
            else
            {
                throw new ArgumentNullException("Error search: argument null");
            }
        }

        public async Task<IEnumerable<Document>> GetEntitys()
        {
            return await EntitySourceContext.Documents.ToListAsync();
        }
    }
}
