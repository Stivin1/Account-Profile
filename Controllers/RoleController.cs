using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.HomeService;
using OpenSourceEntitys.Models.ModelControllers.ListRoles.ListRoleVeiw;
using OpenSourceEntitys.Models.ServiceRole;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;

        private UserManager<User> UserManager { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private RoleManager<IdentityRole> RoleManager { get; set; }

        private IServiceRole IServiceRole { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public RoleController(
            ILogger<RoleController> logger,
            UserManager<User> UserManager,
            EntitySourceContext EntitySourceContext,
            RoleManager<IdentityRole> RoleManager,
            HomeService HomeService,
            IServiceRole IServiceRole,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.RoleManager = RoleManager;
            this.IServiceRole = IServiceRole;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AppendRole(string UserId, int page = 1)
        {
            var usersearc = await UserManager.FindByIdAsync(UserId);
            var rolesearch = await RoleManager.Roles.ToListAsync();

            ListRolesPagination listRolesPagination = new ListRolesPagination(page, 7, rolesearch.Count());

            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingdatafromtheaddrolepage);

                return View(new Role
                {
                    UserId = usersearc.Id,
                    IdentityRoles = rolesearch.Skip((page - 1) * 7).Take(7),
                    ListRolesPagination = listRolesPagination,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AppendRole(Role Role)
        {
            if (ModelState.IsValid)
            {
                var result = await IServiceRole.AppendRole(Role.RoleName);

                if (result.Succeeded)
                {
                    await UnitLogOfWork.RepositoryLogging.InsertLog(Role.UserId, InformationLoggingEnum.AddingaRolebyaUser);

                    return RedirectToAction("AppendRole", "Role",new { UserId = Role.UserId });
                }
                else
                {
                    foreach(var list in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,list.Description);
                    }
                }

            }

            return RedirectToAction("AppendRole", "Role",new { UserId = Role.UserId });
        }

        [HttpGet]
        public async Task<IActionResult> AppendRoleAccount(string UserId, int page = 1)
        {
            var usersearc = await UserManager.FindByIdAsync(UserId);

            var roles = await RoleManager.Roles.ToListAsync();

            var userrole = await UserManager.GetRolesAsync(usersearc);

            ListRolesPagination listRolesPagination = new ListRolesPagination(page, 7, roles.Count());

            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingthedataofthepageforaddingaroletoauser);

                return View(new AppendRoleAccount
                {
                    UserId = usersearc.Id,
                    UserName = usersearc.UserName,
                    IdentityRoles = roles.Skip((page - 1) * 7).Take(7),
                    AddRole = userrole,
                    ListRolesPagination = listRolesPagination,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
                }) ;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AppendRoleAccount(string UserId,  List<string> RoleName)
        {
            var usersearc = await UserManager.FindByIdAsync(UserId);

            if(ModelState.IsValid)
            {
                if (usersearc != null)
                {
                    var userroles = await UserManager.GetRolesAsync(usersearc);

                    var add = RoleName.Except(userroles);
                    var remove = userroles.Except(RoleName);

                    await IServiceRole.AppendListUsersRole(usersearc, add);
                    await IServiceRole.DeleteListUsersRole(usersearc, remove);
                }
            }

            return RedirectToAction("AppendRoleAccount", "Role", new { UserId = UserId });
        }
    }
}