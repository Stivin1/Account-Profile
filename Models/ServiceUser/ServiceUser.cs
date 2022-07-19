using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ServiceParticipant.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceUser
{
    public class ServiceUser : IServiceUser, IServiceAuthorization
    {
        private UserManager<User> UserManager { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        public ServiceUser(UserManager<User> UserManager, EntitySourceContext EntitySourceContext)
        {
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<IdentityResult> AddRegServiceUser(User user, string password)
        {
            if(user == null)
                throw new ArgumentNullException("Error AddRegServiceUser UserManager CreateAsync is argument null");

            return await UserManager.CreateAsync(user, password);
        }

        public User CreateUser(Registration registration)
        {
            if (
                string.IsNullOrEmpty(registration.Email) ||
                string.IsNullOrEmpty(registration.UserName) ||
                string.IsNullOrEmpty(registration.Password) ||
                registration?.DomenId == null
              )
                throw new ArgumentNullException("Error CreateUser Mappging is argument null");

            User user = new User
            {
                Email = registration.Email,
                UserName = registration.UserName,
                DateCreate = DateTime.Now.ToString(),
                DomainId = registration.DomenId,
                CountryId = registration.CountryId,
                ConsentProvisionPersonalData = registration.ConsentProvisionPersonalData,
                Year = EextensionAge.GetParticipantAge(registration.DateAge)
                
            };
            if (user == null)
                throw new ArgumentNullException("Error CreateUser Mappging  user is argument null");

            return user;
        }

        public async Task<IdentityResult> UpdatePasswordAccount(User user , string oldpassword, string newpassword)
        {
            IdentityResult identityResult = null;

            if (user.Id != null)
            {
                identityResult = await UserManager.ChangePasswordAsync(user, oldpassword, newpassword);

                var resutluser = await EntitySourceContext.Users.FirstOrDefaultAsync(t => t.Id == user.Id);

                resutluser.DateChanges = DateTime.Now.ToString();

                EntitySourceContext.Users.Update(resutluser);

                await EntitySourceContext.SaveChangesAsync();

            }

            return identityResult;
        }

        public async Task<int> UpdateUserNameAccount(User user,string UserName)
        {

            if (user.Id != null)
            {
                var resutluser = await EntitySourceContext.Users.FirstOrDefaultAsync(t => t.Id == user.Id);

                resutluser.UserName = UserName;
                
                resutluser.DateChanges = DateTime.Now.ToString();

                EntitySourceContext.Users.Update(resutluser);

                await EntitySourceContext.SaveChangesAsync();
            }

            return 1;
        }

        public async Task<int> Entrance(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User is null to in method Entrance");

            user.DateLastEntry = DateTime.Now.ToString();

            EntitySourceContext.Users.Update(user);

            await EntitySourceContext.SaveChangesAsync();

            return 1;
        }
    }
}
