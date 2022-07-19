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
using OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserDeletedDocument;
using OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument;
using OpenSourceEntitys.Models.ServiceDocument;
using static OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.RepositoryLogger.LoggingTypes.LoggingEnum;
using static OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserDeletedDocument.ListUserDeletedDocumentSorting;
using static OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument.ListUserForDocumentSorting;

namespace OpenSourceEntitys.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly ILogger<DocumentController> _logger;

        private UserManager<User> UserManager { get; set; }

        private SignInManager<User> SignInManager { get; set; }

        private IDocumentService DocumentService { get; set; }

        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        private IUnitLogOfWork UnitLogOfWork { get; set; }

        public DocumentController(
            ILogger<DocumentController> logger,
            UserManager<User> UserManager,
            SignInManager<User> SignInManager,
            EntitySourceContext EntitySourceContext,
            IDocumentService DocumentService,
            IUnitOfWork UnitOfWork,
            IUnitLogOfWork UnitLogOfWork
            )
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.EntitySourceContext = EntitySourceContext;
            this.UnitOfWork = UnitOfWork;
            this.SignInManager = SignInManager;
            this.DocumentService = DocumentService;
            this.UnitLogOfWork = UnitLogOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string UserId, string Name, string DateCreate, int? DocumentId, int page = 1, DocumentForSorting Sorting = DocumentForSorting.DocumentAsc)
        {
            if (DocumentId != null)
                await DocumentService.DeleteDocument(UserId, DocumentId);

            var selectlistdoctype = await UnitOfWork.RepositoryDocumentType.GetEntitys();

            var listdocument = await DocumentService.GetListUserDocuments(UserId);

            ListUserForDocumentFiltering ListUsersFiltering = new ListUserForDocumentFiltering(listdocument);

            var filtering = ListUsersFiltering.ListDocumentGetFiltering(Name, DateCreate, UserId);

            ListUserForDocumentSorting ListUserForDocumentSorting = new ListUserForDocumentSorting(Sorting);

            var sorting = ListUserForDocumentSorting.GetListDocumentForSorting(filtering, Sorting);

            ListUserForDocumentPagination ListUserForDocumentPagination = new ListUserForDocumentPagination(page, 7, listdocument.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Gettingpagedatamydocuments);

            return View(new UserDocument
            {
                UserId = UserId,
                Name = Name,
                DateCreate = DateCreate,
                Documents = sorting.Skip((page - 1) * 7).Take(7),
                ListUserForDocumentFiltering = ListUsersFiltering,
                ListUserForDocumentSorting = ListUserForDocumentSorting,
                ListUserForDocumentPagination = ListUserForDocumentPagination,
                DocumentTypes = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectlistdoctype, "id","NameType"),
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                       .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                           .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                           .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                           || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }


        [HttpGet]
        public async Task<IActionResult> CreateDocument(string UserId , int page = 1)
        {
            var listdocument = await DocumentService.GetListUserDocuments(UserId);

            ListUserForDocumentPagination ListUserForDocumentPagination = new ListUserForDocumentPagination(page, 7, listdocument.Count());
            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.Addingadocument);

            return View(new CreateDocument
            {
                UserId = UserId,
                Documents = listdocument.Skip((page - 1) * 7).Take(7),
                ListUserForDocumentPagination = ListUserForDocumentPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            }) ;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument(CreateDocument CreateDocument)
        {
            bool type = false;

            if (!string.IsNullOrEmpty(CreateDocument?.Avatar?.FileName))
            {
                type = DocumentService.GetTypeIsValid(CreateDocument.Avatar.FileName);
            }

            if (type == false)
            {
                ModelState.AddModelError("Avatar", "Тип не поддерживается");
            }

            if (ModelState.IsValid)
            {
                await DocumentService.CreateDocument(CreateDocument.UserId, CreateDocument.Avatar);
            }

            var listdocument = await DocumentService.GetListUserDocuments(CreateDocument.UserId);

            ListUserForDocumentPagination ListUserForDocumentPagination = new ListUserForDocumentPagination(1, 7, listdocument.Count());

            return View(new CreateDocument
            {
                UserId = CreateDocument.UserId,
                Documents = listdocument.Skip((1 - 1) * 7).Take(7),
                ListUserForDocumentPagination = ListUserForDocumentPagination,
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == CreateDocument.UserId || t.RecipientId == CreateDocument.UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == CreateDocument.UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == CreateDocument.UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }

        [HttpGet]
        public async Task<IActionResult> DocumentDeleted(string UserId, string Name, string DateDeleted, int page = 1, DocumentDeletedSorting DelSorting = DocumentDeletedSorting.DocumentAsc)
        {
            var selectlistdoctype = await UnitOfWork.RepositoryDocumentType.GetEntitys();

            var listdocument = await DocumentService.GetListDelUserDocuments(UserId);

            ListUserDeletedDocumentFiltering ListUsersFiltering = new ListUserDeletedDocumentFiltering(listdocument);

            var filtering = ListUsersFiltering.ListDocumentGetFiltering(Name, DateDeleted, UserId);

            ListUserDeletedDocumentSorting ListUserForDocumentSorting = new ListUserDeletedDocumentSorting(DelSorting);

            var sorting = ListUserForDocumentSorting.GetListDocumentDeletedSorting(filtering, DelSorting);

            ListUserDeletedDocumentPagination ListUserDeletedDocumentPagination = new ListUserDeletedDocumentPagination(page, 7, listdocument.Count());

            await UnitLogOfWork.RepositoryLogging.InsertLog(UserId, InformationLoggingEnum.RetrievingDocumentBasketPageData);

            return View(new DocumentDeleted
            {
                UserId = UserId,
                Name = Name,
                DateDeleted = DateDeleted,
                Documents = sorting.Skip((page - 1) * 7).Take(7),
                ListUserDeletedDocumentFiltering = ListUsersFiltering,
                ListUserDeletedDocumentSorting = ListUserForDocumentSorting,
                ListUserDeletedDocumentPagination = ListUserDeletedDocumentPagination,
                DocumentTypes = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectlistdoctype, "id", "NameType"),
                HelpersDisplayCountMessage = EntitySourceContext.addresSents
                .Include(t => t.User).Where(t => t.UserId == UserId || t.RecipientId == UserId).ToList().Count(),
                HelpersDeletedCountMessage = EntitySourceContext.MessageSettings
                .Include(t => t.Message).ThenInclude(t => t.AddresSent).ThenInclude(t => t.User)
                .Where(t => (t.UserId == UserId && t.MessageDonorIsHidden == true)
                || (t.UserRecipientId == UserId && t.MessageRecipientIsHidden == true)).ToList().Count()
            });
        }

        [HttpPost]
        public async Task<IActionResult> DocumentRecover(string UserId, int? DocumentId)
        {
            if (DocumentId != null)
                await DocumentService.RecoverDocument(UserId, DocumentId);

            return RedirectToAction("DocumentDeleted","Document",new { UserId =  UserId , DocumentId = DocumentId });
        }

        [HttpGet]
        public async Task<IActionResult> Download(int DocumentId)
        {
            byte[] documentbyte;

            var document = await EntitySourceContext.Documents.FirstOrDefaultAsync(t => t.id == DocumentId);

            documentbyte = document.Text;

            return File(documentbyte, "text/plain", document.Name);
        }
    }
}