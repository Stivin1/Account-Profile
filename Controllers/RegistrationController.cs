using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ServiceParticipant;
using OpenSourceEntitys.Models.ServiceUser;

namespace OpenSourceEntitys.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;

        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        private UserManager<User> UserManager { get; set; }

        private ServiceParticipant ServiceParticipant { get; set; }

        private ServiceUser ServiceUser { get; set; }

        public RegistrationController(
            ILogger<RegistrationController> logger,
            EntitySourceContext EntitySourceContext,
            IUnitOfWork UnitOfWork,
            UserManager<User> UserManager,
            ServiceParticipant ServiceParticipant,
            ServiceUser ServiceUser
            )
        {
            _logger = logger;
            this.UnitOfWork = UnitOfWork;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.ServiceParticipant = ServiceParticipant;
            this.ServiceUser = ServiceUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string FrontEmail)
        {
            var country = await UnitOfWork.RepositoryCountry.GetEntitys();
            var pol = await UnitOfWork.RepositoryPol.GetEntitys();
            var domain = await UnitOfWork.RepositoryDomain.GetEntitys();


            Registration registration = new Registration
            {
                SelectCountry = new SelectList(country, "id", "Name"),
                SelectPol = new SelectList(pol, "id", "Name"),
                SelectDomen = new SelectList(domain, "id", "Name"),
                Email = FrontEmail
            };

            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Registration registration)
        {
            var country = await UnitOfWork.RepositoryCountry.GetEntitys();
            var pol = await UnitOfWork.RepositoryPol.GetEntitys();
            var domain = await UnitOfWork.RepositoryDomain.GetEntitys();

            var validdomen = await EntitySourceContext.Domains.FindAsync(registration.DomenId);

            if (registration.Email == null || !registration.Email.Contains(validdomen.Name))
            {
                ModelState.AddModelError("Email", "Указан не верный домен");
            }

            if (ModelState.IsValid)
            {
                var searchuser = UserManager.Users.FirstOrDefault(t => t.Email == registration.Email);

                if (searchuser == null)
                {
                    var reguser = ServiceUser.CreateUser(registration);

                    if (reguser != null)
                    {
                        var userconfirm = await ServiceUser.AddRegServiceUser(reguser, registration.Password);

                        if (userconfirm.Succeeded)
                        {
                            var part = ServiceParticipant.SetMappgingRegParticipant(registration, reguser);

                            await ServiceParticipant.CreateParticipant(part);

                            return RedirectToAction("SuccessfulRegistration", "Registration");
                        }
                    }
                }
            }

            return View(new Registration
            {
                SelectCountry = new SelectList(country, "id", "Name"),
                SelectPol = new SelectList(pol, "id", "Name"),
                SelectDomen = new SelectList(domain, "id", "Name"),
            });
        }

        [HttpGet]
        public IActionResult SuccessfulRegistration()
        {
            return View();
        }
    }
}