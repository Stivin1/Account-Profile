using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListDocument.ListUserForDocument
{
    public class ListUserForDocumentFiltering
    {
        public IEnumerable<Document> Document { get; set; }

        public ListUserForDocumentFiltering(IEnumerable<Document> Document)
        {
            this.Document = Document;
        }

        public IEnumerable<Document> ListDocumentGetFiltering(string Name, string DateCreate, string UserId)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                Document = Document.Where(t => t.Name.Contains(Name) && t.UserId == UserId);
            }

            if (!string.IsNullOrEmpty(DateCreate))
            {
                Document = Document.Where(t => t.DateCreate.Contains(DateCreate) && t.UserId == UserId);
            }

            return Document;
        }
    }
}
