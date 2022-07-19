using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IRepository
{
    public interface IRepositoryLogging : IRepository<Logging>
    {
        //<summary>
        //Дополнительное свойство предоставляющее логирования
        //</summary>
        public LoggingEnum loggingEnum { get; set; }
    }
}
