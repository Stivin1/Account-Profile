using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.EntitysEnum.Новая_папка;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceDocument
{
    public class DocumentService : IDocumentService
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public DocumentService
            (
            EntitySourceContext EntitySourceContext
            )
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<IEnumerable<Document>> GetListUserDocuments(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
                throw new ArgumentNullException("Error null argument in method parament UserId");

            var listdocument = await EntitySourceContext.Documents
                .Include(t => t.DocumentType)
                .Include(t => t.User)
                .Include(t => t.User.Profile)
                .Where(t => t.UserId == UserId && t.IsDeleted == false)
                .ToListAsync();

            return listdocument;
        }

        public async Task<int> CreateDocument(string UserId, IFormFile formFile)
        {
            try
            {
                byte[] file;

                using (BinaryReader reader = new BinaryReader(formFile.OpenReadStream()))
                {
                    file = reader.ReadBytes((int)formFile.Length);
                }

                var resultdoctype = DocumentTypeParce(formFile.ContentDisposition);

                if (resultdoctype == 0) return 0;

                Document document = new Document
                {
                    Name = formFile.FileName,
                    DocumentTypeId = resultdoctype,
                    Text = file,
                    IsDeleted = false,
                    UserId = UserId,
                    DateCreate = DateTime.Now.ToString()
                };

                await EntitySourceContext.AddAsync(document);
                await EntitySourceContext.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }

        private int DocumentTypeParce(string type)
        {
            if (type.Contains(".txt"))
            {
               return (int)DocumentEnum.GetDocumentEnums(DocumentEnum.DocumentEnums.txt);
            }

            if (type.Contains(".doc"))
            {
                return (int)DocumentEnum.GetDocumentEnums(DocumentEnum.DocumentEnums.doc);
            }

            if (type.Contains(".docx"))
            {
                return (int)DocumentEnum.GetDocumentEnums(DocumentEnum.DocumentEnums.docx);
            }

            if (type.Contains(".xlsx"))
            {
                return (int)DocumentEnum.GetDocumentEnums(DocumentEnum.DocumentEnums.xlsx);
            }

            return 0;
        }

        public bool GetTypeIsValid(string value)
        {
            var type = EntitySourceContext.DocumentTypes.ToList();

            foreach (var list in type)
            {
                if (list?.NameType != null)
                {
                    if (value.Contains(list.NameType))
                    {
                        return true;
                    }
                }
            }

            return false; 
        }


        public async Task<IEnumerable<Document>> GetListDelUserDocuments(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
                throw new ArgumentNullException("Error null argument in method parament UserId");

            var listdocument = await EntitySourceContext.Documents
                .Include(t => t.DocumentType)
                .Include(t => t.User)
                .Include(t => t.User.Profile)
                .Where(t => t.UserId == UserId && t.IsDeleted == true)
                .ToListAsync();

            return listdocument;
        }

        public async Task<int> DeleteDocument(string UserId, int? DocumentId)
        {
            if (string.IsNullOrEmpty(UserId))
                throw new ArgumentNullException("Error null argument in method parament UserId");

            var document = await EntitySourceContext.Documents.FirstOrDefaultAsync(t => t.UserId == UserId && t.id == DocumentId);

            if(document != null)
            {
                document.IsDeleted = true;
                document.DateDeleted = DateTime.Now.ToString();

                EntitySourceContext.Update(document);
                await EntitySourceContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Error null argument in method DeleteDocument parament document");
            }

            return 1;
        }

        public async Task<int> RecoverDocument(string UserId, int? DocumentId)
        {
            if (string.IsNullOrEmpty(UserId))
                throw new ArgumentNullException("Error null argument in method parament UserId");

            var document = await EntitySourceContext.Documents.FirstOrDefaultAsync(t => t.UserId == UserId && t.id == DocumentId);

            if (document != null)
            {
                document.IsDeleted = false;
                document.DateDeleted = null;

                EntitySourceContext.Update(document);
                await EntitySourceContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Error null argument in method DeleteDocument parament document");
            }

            return 1;
        }
    }
}
