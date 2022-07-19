using Microsoft.AspNetCore.Http;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceDocument
{
    public interface IDocumentService
    {
        public Task<IEnumerable<Document>> GetListUserDocuments(string UserId);

        public Task<IEnumerable<Document>> GetListDelUserDocuments(string UserId);

        public Task<int> CreateDocument(string UserId, IFormFile formFile);

        public Task<int> DeleteDocument(string UserId, int? DocumentId);

        public Task<int> RecoverDocument(string UserId, int? DocumentId);

        public bool GetTypeIsValid(string value);
    }
}
