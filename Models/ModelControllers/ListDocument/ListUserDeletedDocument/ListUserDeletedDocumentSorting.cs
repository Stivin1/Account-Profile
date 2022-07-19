using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserDeletedDocument
{
    public class ListUserDeletedDocumentSorting
    {
        public enum DocumentDeletedSorting
        {
            DocumentAsc,
            DocumentDesc,
            DateDeletedAsc,
            DateDeletedDesc,
            Default
        }

        public DocumentDeletedSorting Name;

        public DocumentDeletedSorting DateCreate;

        public DocumentDeletedSorting Default;

        public ListUserDeletedDocumentSorting(DocumentDeletedSorting DocumentDeletedSorting)
        {
            Default = DocumentDeletedSorting;

            Name = DocumentDeletedSorting == DocumentDeletedSorting.DocumentAsc ? DocumentDeletedSorting.DocumentDesc : DocumentDeletedSorting.DocumentAsc;

            DateCreate = DocumentDeletedSorting == DocumentDeletedSorting.DateDeletedAsc ? DocumentDeletedSorting.DateDeletedDesc : DocumentDeletedSorting.DateDeletedAsc;
        }

        public IEnumerable<Document> GetListDocumentDeletedSorting(IEnumerable<Document> Document, DocumentDeletedSorting DocumentDeletedSorting)
        {
            switch (DocumentDeletedSorting)
            {
                case DocumentDeletedSorting.DocumentAsc:
                    Document = Document.OrderBy(t => t.Name);
                    break;
                case DocumentDeletedSorting.DocumentDesc:
                    Document = Document.OrderByDescending(t => t.Name);
                    break;
                case DocumentDeletedSorting.DateDeletedAsc:
                    Document = Document.OrderBy(t => t.DateDeleted);
                    break;
                case DocumentDeletedSorting.DateDeletedDesc:
                    Document = Document.OrderByDescending(t => t.DateDeleted);
                    break;
                default: throw new Exception("Error null search element in GetListDocumentDeletedSorting");
            }

            return Document;
        }
    }
}
