using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.IUnitLogOfWork;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUserView;
using OpenSourceEntitys.Models.ServiceGroup;
using OpenSourceEntitys.Models.ServiceParticipant;
using OpenSourceEntitys.Models.ServiceUser;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;
using static OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups.ListUsersGroupsSorting;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;

        private UserManager<User> UserManager { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private IGroupService IGroupService { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public GroupController(
            ILogger<GroupController> logger,
            UserManager<User> UserManager,
            EntitySourceContext EntitySourceContext,
            IGroupService IGroupService,
            IUnitOfWork UnitOfWork,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.IGroupService = IGroupService;
            this.UnitOfWork = UnitOfWork;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AppendGroups(string UserId, int page = 1)
        {
            var usersearc = await UserManager.FindByIdAsync(UserId);

            var listgroups = await UnitOfWork.RepositoryGroups.GetEntitys();

            ListGroupsPagination ListUsersPagination = new ListGroupsPagination(page, 7, listgroups.Count());

            if (usersearc != null)
            {
                await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingpagedataforaddingagroup);

                return View(new AppendGroups
                {
                    UserId = usersearc.Id,
                    Groups = listgroups.Skip((page - 1) * 7).Take(7),
                    ListGroupsPagination = ListUsersPagination,
                    HelpersDisplayCountMessage = EntitySourceContext.addresSents
                           .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                    HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()

                }); ;
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AppendGroups(AppendGroups Group, int page = 1)
        {
            
            if (ModelState.IsValid)
            {
                await IGroupService.CreateGroup(Group.UserId, Group.GroupName);
            }

            var usersearc = await UserManager.FindByIdAsync(Group.UserId);

            var listgroups = await UnitOfWork.RepositoryGroups.GetEntitys();

            ListGroupsPagination ListGroupsPagination = new ListGroupsPagination(page, 7, listgroups.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(Group.UserId, InformationLoggingEnum.Addingagroupbyauser);

            return View(new AppendGroups
            {
                UserId = usersearc.Id,
                Groups = listgroups.Skip((page - 1) * 7).Take(7),
                ListGroupsPagination = ListGroupsPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                      .Include(t => t.User).Where(t => t.UserId == Group.UserId || t.RecipientId == Group.UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == Group.UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == Group.UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }

        [HttpGet]
        public async Task<IActionResult> AppendGroupsAccount(string UserId, int menupage = 1, int menuuserpage = 1)
        {
            var usersearc = await UserManager.FindByIdAsync(UserId);

            if (usersearc != null)
            {
                var listusergroups = await IGroupService.GetSearchListUsersGroup(UserId);

                var listgroups = await IGroupService.GetListGroups();

                ListGroupsPagination ListGroupsPagination = new ListGroupsPagination(menupage, 7, listgroups.Count());

                ListGroupsPagination ListGroupsUsersPagination = new ListGroupsPagination(menuuserpage, 5, listusergroups.Count());

                await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingpagedataforaddingagrouptoauser);

                return View(new AppendGroupAccount
                {
                    UserId = usersearc.Id,
                    Email = usersearc.Email,
                    UserListGroups = listusergroups.Skip((menuuserpage - 1) * 5).Take(5),
                    Groups = listgroups.Skip((menupage - 1) * 7).Take(7),
                    ListGroupsPagination = ListGroupsPagination,
                    ListGroupsUsersPagination = ListGroupsUsersPagination,
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
        public async Task<IActionResult> AppendGroupsAccount(string UserId, string UserGroups, int Operation)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(UserId);

                if(Operation == 1)
                {
                    await IGroupService.AppendListUsersGroup(user.Id, UserGroups);

                    await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Addingagrouptoauser);

                }
                else
                    if(Operation == 2)
                {

                    await IGroupService.DeleteListUsersGroup(user.Id, UserGroups);

                    await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Deletingausergroup);
                }
            }

            return RedirectToAction("AppendGroupsAccount","Group", new { UserId = UserId});
        }

        [HttpGet]
        public async Task<IActionResult> ListUsersGroups(string UserId, string Name, string DateCreate, int page = 1, UsersGroupsSorting Sorting = UsersGroupsSorting.NameAsc)
        {
            var groups = await IGroupService.GetUsersGroupsView();

            ListUsersGroupsFiltering ListUsersGroupsFiltering = new ListUsersGroupsFiltering(groups);

            var filtering = ListUsersGroupsFiltering?.ListUsersGetFiltering(Name, DateCreate);

            ListUsersGroupsSorting ListUsersGroupsSorting = new ListUsersGroupsSorting(Sorting);

            var sorting = ListUsersGroupsSorting?.GetListUsersGroupsSorting(filtering, Sorting);

            ListUsersGroupsPagination ListUsersGroupsPagination = new ListUsersGroupsPagination(page, 7, groups.Count());

            return View(new ListUsersGroups
            {
                UserId = UserId,
                Name = Name,
                DateCreate = DateCreate,
                UsersGroupsView = sorting.Skip((page - 1) * 7).Take(7),
                ListUsersGroupsFiltering = ListUsersGroupsFiltering,
                ListUsersGroupsSorting = ListUsersGroupsSorting,
                ListUsersGroupsPagination = ListUsersGroupsPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });;
        }
    }
}