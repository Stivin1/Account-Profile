using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceRole
{
    public interface IServiceRole
    {
        public Task<IdentityResult> AppendRole(string Name);

        public Task<int> AppendInRoleUser(User user);

        public Task<int> AppendListUsersRole(User user, IEnumerable<string> RoleName);

        public Task<int> DeleteListUsersRole(User user, IEnumerable<string> RoleName);
    }
}
