using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.HomeService;
using OpenSourceEntitys.Models.ModelCore;
using OpenSourceEntitys.Models.ServiceParticipant;
using OpenSourceEntitys.Models.ServiceReport;
using OpenSourceEntitys.Models.ServiceUser;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private UserManager<User> UserManager { get; set; }

        private SignInManager<User> SignInManager { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private HomeService HomeService { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        private ServiceParticipant ServiceParticipant { get; set; }

        private ServiceUser ServiceUser { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<User> UserManager,
            SignInManager<User> SignInManager,
            EntitySourceContext EntitySourceContext,
            HomeService HomeService,
            IUnitOfWork UnitOfWork,
            ServiceParticipant ServiceParticipant,
            ServiceUser ServiceUser,
            IUnitLogOfWork UnitLogOfWork,
            IServiceReport IServiceReport
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.HomeService = HomeService;
            this.UnitOfWork = UnitOfWork;
            this.ServiceParticipant = ServiceParticipant;
            this.ServiceUser = ServiceUser;
            this.SignInManager = SignInManager;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usersearc = await HomeService.GetSearchInHomeUser(User.Identity.Name);

                if (usersearc != null)
                {
                    await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id,InformationLoggingEnum.Getprofilepagedata);

                    return View(new Home
                    {
                        ConfigRootCore = new ConfigRootCore
                        {
                            UserCore = usersearc,
                            ParticipantCore = usersearc.Profile
                        },
                        HelpersDisplayCountMessage = EntitySourceContext.addresSents
                        .Include(t => t.User).Where(t => t.UserId == usersearc.Id || t.RecipientId == usersearc.Id).ToList().Count(),
                        HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                        .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                        .Where(t =>  ( t.UserId == usersearc.Id  &&  t.MessageDonorIsHidden == true ) 
                        || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                    });
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile(string UserId)
        {
            var usersearc = await HomeService.GetSearchInHomeUser(User.Identity.Name);

            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Getprofilepagedata);

                return View(new UpdateProfile
                {
                    UserId = UserId,
                    Participant = usersearc.Profile,
                    SelectCountry = new SelectList(await UnitOfWork.RepositoryCountry.GetEntitys(), "id", "Name"),
                    SelectPol = new SelectList(await UnitOfWork.RepositoryPol.GetEntitys(), "id", "Name"),
                    SelectDomen = new SelectList(await UnitOfWork.RepositoryDomain.GetEntitys(), "id", "Name"),
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == usersearc.Id).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                    .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                    .Where(t => (t.UserId == usersearc.Id && t.MessageDonorIsHidden == true)
                    || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost] 
        public async Task<IActionResult> UpdateProfile(UpdateProfile UpdateProfile)
        {
            var usersearc = await HomeService.GetSearchInHomeUser(User.Identity.Name);

            if (usersearc != null)
            {
                await ServiceParticipant.UpdateParticipant(UpdateProfile);

                await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Changingprofileinformation);

                return View(new UpdateProfile
                {
                    UserId = UpdateProfile.UserId,
                    Participant = usersearc.Profile,
                    SelectCountry = new SelectList(await UnitOfWork.RepositoryCountry.GetEntitys(), "id", "Name"),
                    SelectPol = new SelectList(await UnitOfWork.RepositoryPol.GetEntitys(), "id", "Name"),
                    SelectDomen = new SelectList(await UnitOfWork.RepositoryDomain.GetEntitys(), "id", "Name"),
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == usersearc.Id || t.RecipientId == usersearc.Id).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                    .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                    .Where(t => (t.UserId == usersearc.Id && t.MessageDonorIsHidden == true)
                    || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAccount(string UserId)
        {
            var usersearc = await HomeService.GetSearchInHomeUser(User.Identity.Name);
            
            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Retrievinguserchangepagedata);

                return View(new UpdateAccount
                {
                    UserId = UserId,
                    Email = usersearc.Email,
                    UserName = usersearc.UserName,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                    .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                    .Where(t => (t.UserId == usersearc.Id && t.MessageDonorIsHidden == true)
                    || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(UpdateAccount UpdateAccount)
        {
            var usersearc = await UserManager.FindByEmailAsync(UpdateAccount.Email);

            if (ModelState.IsValid)
            {
                if (usersearc != null)
                {
                    await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Changinguserdata);

                    await ServiceUser.UpdateUserNameAccount(usersearc, UpdateAccount.UserName);

                    return await OutAccount(usersearc.Id);
                }
            }

            return View(UpdateAccount);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePassword(string UserId)
        {
            var usersearc = await HomeService.GetSearchInHomeUser(User.Identity.Name);

            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Getpagedatachangepassword);

                return View(new UpdatePassword
                {
                    UserId = UserId,
                    Email = usersearc.Email,
                    UserName = usersearc.UserName,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                    .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                    .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                    .Where(t => (t.UserId == usersearc.Id && t.MessageDonorIsHidden == true)
                    || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePassword UpdatePassword)
        {
            var usersearc = await UserManager.FindByIdAsync(UpdatePassword.UserId);

            if (ModelState.IsValid)
            {
                if (usersearc != null)
                {
                    var result = await ServiceUser.UpdatePasswordAccount(usersearc, UpdatePassword.OldPassword, UpdatePassword.NewPassword);

                    if(result.Succeeded)
                    {
                        await UnitLogOfWork.RepositoryLogging.InsertLog(usersearc.Id, InformationLoggingEnum.Changinguserdata);

                        return await OutAccount(UpdatePassword.UserId);
                    }
                    else
                    {
                        foreach(var errors in result.Errors)
                        {
                            ModelState.AddModelError("", errors.Description);
                        }
                    }
                }
            }

            return View(new UpdatePassword
            {
                UserId = usersearc.Id,
                Email = usersearc.Email,
                UserName = usersearc.UserName,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == usersearc.Id || t.RecipientId == usersearc.Id).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == usersearc.Id && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == usersearc.Id && t.MessageRecipientIsHidden == true)).ToList().Count()
            });;
        }


        public async Task<IActionResult> OutAccount(string UserId)
        {
            var user = UserManager.Users.FirstOrDefault(t => t.Id == UserId);

            await UnitLogOfWork.RepositoryLogging.InsertLog(user.Id, InformationLoggingEnum.Userlogout);

            await SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Authorization");
        }

        [HttpGet]
        public async Task<IActionResult> UserDownload(string UserId)
        {
            ServiceReport ServiceReport = new ServiceReport(new ServiceUserReport(EntitySourceContext));

            var report = await ServiceReport.GetGeneratedFile(UserId);

            return File(report.Reports, "text/plain", "Изменения пользователя.txt");
        }

        [HttpGet]
        public async Task<IActionResult> ProfileDownload(string UserId)
        {
            ServiceReport ServiceReport = new ServiceReport(new ServiceProfileReport(EntitySourceContext));

            var report = await ServiceReport.GetGeneratedFile(UserId);

            return File(report.Reports, "text/plain", "Изменения профиля.txt");
        }

        [HttpGet]
        public async Task<IActionResult> ActiveDownload(string UserId)
        {
            ServiceReport ServiceReport = new ServiceReport(new ServiceActiveReport(EntitySourceContext));

            var report = await ServiceReport.GetGeneratedFile(UserId);

            return File(report.Reports, "text/plain", "Активность аккаунта.txt");
        }
    }
}