using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Service.ServiceAuthorization
{
    public static class ServiceAuthorization
    {
        public static IServiceCollection AddSerivceAuthentication(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authorization/Index");
                option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Authorization/Index");
            });

            return services;
        }
    }
}
