
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class UserDocument : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string DateCreate { get; set; }

        public int DocumentTypesId { get; set; }

        public SelectList DocumentTypes { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public ListUserForDocumentFiltering ListUserForDocumentFiltering { get; set; }

        public ListUserForDocumentPagination ListUserForDocumentPagination { get; set; }

        public ListUserForDocumentSorting ListUserForDocumentSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
