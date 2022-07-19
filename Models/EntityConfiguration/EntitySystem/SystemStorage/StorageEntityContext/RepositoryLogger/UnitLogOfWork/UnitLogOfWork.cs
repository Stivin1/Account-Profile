using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IRepository;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext
{
    public class UnitLogOfWork : IUnitLogOfWork
    {
        public EntitySourceContext ApplicationEnityContextdb { get; set; }

        public IRepositoryLogging RepositoryLogging { get; set; }

        public UnitLogOfWork(
            EntitySourceContext ApplicationEnityContextdb,
            IRepositoryLogging RepositoryLogging
            )
        {
            this.ApplicationEnityContextdb = ApplicationEnityContextdb;
            this.RepositoryLogging = RepositoryLogging;
        }

        public void Dispose()
        {
            ApplicationEnityContextdb.Dispose();
        }
    }
}
