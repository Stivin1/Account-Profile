using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceRole
{
    public class ServiceRole : IServiceRole
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        private UserManager<User> UserManager { get; set; }

        private RoleManager<IdentityRole> RoleManager { get; set; }

        public ServiceRole(
            EntitySourceContext EntitySourceContext,
            UserManager<User> UserManager,
            RoleManager<IdentityRole> RoleManager
            )
        {
            this.EntitySourceContext = EntitySourceContext;
            this.UserManager = UserManager;
            this.RoleManager = RoleManager;
        }

        public Task<int> AppendInRoleUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AppendRole(string Name)
        {
            var search = await RoleManager.FindByNameAsync(Name);

            IdentityResult result = null;

            if (search == null)
            {
                result = await RoleManager.CreateAsync(new IdentityRole(Name));
            }

            return result;
        }

        public async Task<int> AppendListUsersRole(User user, IEnumerable<string> RoleName)
        {
            await UserManager.AddToRolesAsync(user, RoleName);

            return 1;
        }

        public async Task<int> DeleteListUsersRole(User user, IEnumerable<string> RoleName)
        {
            await UserManager.RemoveFromRolesAsync(user, RoleName);

            return 1;
        }
    }
}
