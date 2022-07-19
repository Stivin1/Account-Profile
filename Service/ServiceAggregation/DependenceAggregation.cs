using Microsoft.Extensions.DependencyInjection;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.IRepositorys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IRepository;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.Repository;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.Repositorys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers.HomeService;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService;
using OpenSourceEntitys.Models.ServiceDocument;
using OpenSourceEntitys.Models.ServiceGroup;
using OpenSourceEntitys.Models.ServiceMessage;
using OpenSourceEntitys.Models.ServiceParticipant;
using OpenSourceEntitys.Models.ServiceReport;
using OpenSourceEntitys.Models.ServiceRole;
using OpenSourceEntitys.Models.ServiceUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Service.ServiceAggregation
{
    public static class DependenceAggregation
    {
        public static IServiceCollection AddServiceAgregate(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUnitLogOfWork, UnitLogOfWork>();
            services.AddTransient<IRepositoryLogging, RepositoryLogging>();
            services.AddTransient<IRepositoryParticipant, RepositoryParticipant>();
            services.AddTransient<IRepositoryCountry, RepositoryCounty>();
            services.AddTransient<IRepositoryPol, RepositoryPol>();
            services.AddTransient<IRepositoryGroups, RepositoryGroups>();
            services.AddTransient<IRepositoryTheme, RepositoryTheme>();
            services.AddTransient<IRepositoryMessage, RepositoryMessage>();
            services.AddTransient<IRepositoryDomain, RepositoryDomain>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IRepositoryAddresSent, RepositoryAddresSent>();
            services.AddTransient<IRepositoryDocumentType, RepositoryDocumentType>();
            services.AddTransient<IRepositoryDocument, RepositoryDocument>();
            services.AddTransient<IListParticipantService, ListParticipantService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IServiceRole, ServiceRole>();
            services.AddTransient<IServiceMessage, ServiceMessage>();
            services.AddTransient<IServiceReport, ServiceActiveReport>();
            services.AddTransient<IServiceReport, ServiceUserReport>();
            services.AddTransient<IServiceReport, ServiceProfileReport>();
            services.AddTransient<HomeService>();
            services.AddTransient<ServiceParticipant>();
            services.AddTransient<ServiceUser>();

            return services;
        }
    }
}
