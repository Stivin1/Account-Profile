using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceUser
{
    public interface IServiceUser
    {
        User CreateUser(Registration registration);

        Task<IdentityResult> AddRegServiceUser(User user, string password);

        Task<IdentityResult> UpdatePasswordAccount(User user,string oldpassword, string newpassword);

        Task<int> UpdateUserNameAccount(User user, string UserName);
    }
}
