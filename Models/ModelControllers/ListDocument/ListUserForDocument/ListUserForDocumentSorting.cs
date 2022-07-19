using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument
{
    public class ListUserForDocumentSorting
    {
        public enum DocumentForSorting
        {
            DocumentAsc,
            DocumentDesc,
            DateCreateAsc,
            DateCreateDesc,
            Default
        }

        public DocumentForSorting Name;

        public DocumentForSorting DateCreate;

        public DocumentForSorting Default;

        public ListUserForDocumentSorting(DocumentForSorting DocumentForSorting)
        {
            Default = DocumentForSorting;

            Name = DocumentForSorting == DocumentForSorting.DocumentAsc ? DocumentForSorting.DocumentDesc : DocumentForSorting.DocumentAsc;

            DateCreate = DocumentForSorting == DocumentForSorting.DateCreateAsc ? DocumentForSorting.DateCreateDesc : DocumentForSorting.DateCreateAsc;
        }

        public IEnumerable<Document> GetListDocumentForSorting(IEnumerable<Document> Document, DocumentForSorting DocumentForSorting)
        {
            switch (DocumentForSorting)
            {
                case DocumentForSorting.DocumentAsc:
                    Document = Document.OrderBy(t => t.Name);
                    break;
                case DocumentForSorting.DocumentDesc:
                    Document = Document.OrderByDescending(t => t.Name);
                    break;
                case DocumentForSorting.DateCreateAsc:
                    Document = Document.OrderBy(t => t.DateCreate);
                    break;
                case DocumentForSorting.DateCreateDesc:
                    Document = Document.OrderByDescending(t => t.DateCreate);
                    break;
                default: throw new Exception("Error null search element in DocumentForSorting");
            }

            return Document;
        }
    }
}
