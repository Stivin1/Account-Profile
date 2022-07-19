using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
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

        public UnitOfWork
            (
            IRepositoryParticipant RepositoryParticipant,
            IRepositoryCountry RepositoryCountry,
            IRepositoryPol RepositoryPol,
            IRepositoryDomain RepositoryDomain,
            IRepositoryGroups RepositoryGroups,
            IRepositoryAddresSent RepositoryAddresSent,
            IRepositoryMessage RepositoryMessage,
            IRepositoryTheme RepositoryTheme,
            IRepositoryDocumentType RepositoryDocumentType,
            IRepositoryDocument RepositoryDocument
            )
        {
            this.RepositoryParticipant = RepositoryParticipant;
            this.RepositoryCountry = RepositoryCountry;
            this.RepositoryPol = RepositoryPol;
            this.RepositoryDomain = RepositoryDomain;
            this.RepositoryGroups = RepositoryGroups;
            this.RepositoryAddresSent = RepositoryAddresSent;
            this.RepositoryMessage = RepositoryMessage;
            this.RepositoryTheme = RepositoryTheme;
            this.RepositoryDocumentType = RepositoryDocumentType;
            this.RepositoryDocument = RepositoryDocument;
        } 
    }
}
