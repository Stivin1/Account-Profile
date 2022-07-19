using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepositoryParticipant RepositoryParticipant { get; set; }

        public IRepositoryCountry RepositoryCountry { get; set; }

        public IRepositoryPol RepositoryPol { get; set; }

        public IRepositoryDomain RepositoryDomain { get; set; }

        public IRepositoryGroups RepositoryGroups { get; set; }

        public IRepositoryAddresSent RepositoryAddresSent { get; set; }

        public IRepositoryMessage RepositoryMessage { get; set; }

        public IRepositoryTheme RepositoryTheme { get; set; }

        public IRepositoryDocumentType RepositoryDocumentType { get; set; }

        public IRepositoryDocument RepositoryDocument { get; set; }
    }
}
