using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;

namespace OpenSourceEntitys.Controllers
{
    public class FrontController : Controller
    {
        private readonly ILogger<FrontController> _logger;

        private IUnitOfWork UnitOfWork { get; set; }

        private UserManager<User> UserManager { get; set; }

        public FrontController(
            ILogger<FrontController> logger,
            IUnitOfWork UnitOfWork,
            UserManager<User> UserManager
            )
        {
            _logger = logger;
            this.UnitOfWork = UnitOfWork;
            this.UserManager = UserManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Front
            {
                GroupCount = UnitOfWork.RepositoryGroups.GetEntitys().Result.Count(),
                ParticipantCount = UnitOfWork.RepositoryParticipant.GetEntitys().Result.Count()
            }) ;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Front front)
        {
            if (ModelState.IsValid)
            {
                var searchreguesr = await UserManager.FindByEmailAsync(front.Email);

                if(searchreguesr == null)
                {
                    return RedirectToActionPermanent("Index","Registration", new { FrontEmail = front.Email });
                }
            }

            return View(new Front
            {
                GroupCount = UnitOfWork.RepositoryGroups.GetEntitys().Result.Count(),
                ParticipantCount = UnitOfWork.RepositoryParticipant.GetEntitys().Result.Count()
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
