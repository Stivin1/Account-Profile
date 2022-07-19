using Microsoft.AspNetCore.Mvc.Rendering;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserDeletedDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class DocumentDeleted : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string DateDeleted { get; set; }

        public int DocumentTypesId { get; set; }

        public SelectList DocumentTypes { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public ListUserDeletedDocumentFiltering ListUserDeletedDocumentFiltering { get; set; }

        public ListUserDeletedDocumentPagination ListUserDeletedDocumentPagination { get; set; }

        public ListUserDeletedDocumentSorting ListUserDeletedDocumentSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
