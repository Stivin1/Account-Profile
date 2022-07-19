using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.HomeService;
using OpenSourceEntitys.Models.ServiceUser;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly ILogger<AuthorizationController> _logger;

        private UserManager<User> UserManager { get; set; }

        private ServiceUser ServiceUser { get; set; }

        private SignInManager<User> SignInManager { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public AuthorizationController(
            ILogger<AuthorizationController> logger,
            UserManager<User> UserManager,
            SignInManager<User> SignInManager,
            ServiceUser ServiceUser,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            this.ServiceUser = ServiceUser;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public IActionResult Index(string Url = null)
        {
            return View(new Authorization { AuthorizationLink = Url });
        }

        [HttpPost]
        public async Task<IActionResult> Index(Authorization author)
        {
            if(ModelState.IsValid)
            {
                var authorconfirm = await SignInManager.PasswordSignInAsync(author.Email, author.Password,true,false);

                if (authorconfirm.Succeeded)
                {
                    if(!string.IsNullOrEmpty(author.AuthorizationLink) && Url.IsLocalUrl(author.AuthorizationLink))
                    {
                        return Redirect(author.AuthorizationLink);
                    }
                    else
                    {
                        await ServiceUser.Entrance(UserManager.FindByEmailAsync(author.Email).Result);

                        await UnitLogOfWork.RepositoryLogging.InsertLog(UserManager.FindByEmailAsync(author.Email).Result.Id, InformationLoggingEnum.Userloginattempt);

                        return RedirectToAction("Index","Home");
                    }
                }
            }

            return View(author);
        }
    }
}