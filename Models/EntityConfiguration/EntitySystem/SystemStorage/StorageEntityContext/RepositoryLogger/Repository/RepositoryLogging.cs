

using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IRepository;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes;
using System;
using System.Linq;
using System.Threading.Tasks;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.Repository
{
    public class RepositoryLogging : IRepositoryLogging
    {
        //<summary>
        //Свой предоставляющее доступ к базе данных
        //</summary>
        private EntitySourceContext optiondb { get; set; }

        //<summary>
        //Свойство предоставляющее за обработку логирования
        //</summary>
        public LoggingEnum loggingEnum { get; set; }

        //<summary>
        //Конструктор предоставляющий инициализацию параметров: 
        ///<param name="ApplicationEnityContextdb">Свой предоставляющее доступ к базе данных.</param>
        //</summary>
        public RepositoryLogging(EntitySourceContext optiondb)
        {
            this.optiondb = optiondb;
            loggingEnum = new LoggingEnum();
        }

        //<summary>
        //Метод отвечающий за обработку логирования пользователя и добавления лога в базу данных
        ///<param name="user">Идентификатор пользователя.</param>
        ///<param name="LogInfo">Справочник логирования.</param>
        //</summary>
        public async Task<int> InsertLog(string user, InformationLoggingEnum LogInfo)
        {
            var logging = loggingEnum.GetInformationLogging(optiondb.Users.FirstOrDefault(t => t.Id == user).Id, LogInfo);

            await optiondb.Loggings.AddAsync(logging);

            await optiondb.SaveChangesAsync();

            return 1;
        }
    }
}
