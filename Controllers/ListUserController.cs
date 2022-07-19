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
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService;
using OpenSourceEntitys.Models.ModelControllers.ListUsersView;
using OpenSourceEntitys.Models.ModelCore;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;
using static OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService.ListParticipantSorting;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class ListUserController : Controller
    {
        private readonly ILogger<ListUserController> _logger;

        private UserManager<User> UserManager { get; set; }

        private IListParticipantService IListUserService { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public ListUserController(
            ILogger<ListUserController> logger,
            IListParticipantService IListUserService,
            UserManager<User> UserManager,
            EntitySourceContext EntitySourceContext,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.IListUserService = IListUserService;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string UserId, string MiddleName, string Name, string LastName, string Email, string UserName, int page = 1, Sorting Sorting = Sorting.NameAsc)
        {
            var listuser = await IListUserService.GetListUserService();

            ListParticipantFiltering ListUsersFiltering = new ListParticipantFiltering(listuser);

            var filtering = ListUsersFiltering.ListUsersGetFiltering(MiddleName, Name, LastName, Email, UserName);

            ListParticipantSorting ListParticipantSorting = new ListParticipantSorting(Sorting);

            var sorting = ListParticipantSorting.GetListParticipantSorting(filtering, Sorting);

            ListParticipantPagination ListUsersPagination = new ListParticipantPagination(page, 7, listuser.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettinguserpagedata);

            return View(new ListUser
            {
                MiddleName = MiddleName,
                Name = Name,
                LastName = LastName,
                UserId = UserId,
                Email = Email,
                UserName = UserName,
                Participants = sorting.Skip((page - 1) * 7).Take(7),
                ListUsersSorting = ListParticipantSorting,
                ListUsersPagination = ListUsersPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()

            }); 

        }
    }
}