using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.HomeService
{
    public class HomeService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        public HomeService(
            IUnitOfWork UnitOfWork,
            EntitySourceContext EntitySourceContext
            )
        {
            this.UnitOfWork = UnitOfWork;
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<User> GetSearchInHomeUser(string username)
        {
            var user = await EntitySourceContext.Users
                .Include(t => t.Country)
                .Include(t => t.Profile)
                .ThenInclude(t => t.Pol)
                .FirstOrDefaultAsync(t => t.UserName == username);

            return user;

        }
    }
}
