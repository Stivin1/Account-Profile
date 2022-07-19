using Microsoft.AspNetCore.Http;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.Attributes;
using OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class CreateDocument : IHelpersCountMessage
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Выберите файл")]
        public IFormFile Avatar { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public ListUserForDocumentFiltering ListUserForDocumentFiltering { get; set; }

        public ListUserForDocumentPagination ListUserForDocumentPagination { get; set; }

        public ListUserForDocumentSorting ListUserForDocumentSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
