using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<int> InsertLog(string user, InformationLoggingEnum LogInfo);
    }
}
