using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.EntitysEnum.Новая_папка
{
    public static class DocumentEnum
    {
        public enum DocumentEnums
        {
            txt = 1,
            doc = 2,
            docx = 5,
            xlsx = 6
        }

        public static DocumentEnums GetDocumentEnums(DocumentEnums DocumentEnums)
        {
            return DocumentEnums switch
            {
                DocumentEnums.txt => DocumentEnums.txt,
                DocumentEnums.doc => DocumentEnums.doc,
                DocumentEnums.docx => DocumentEnums.docx,
                DocumentEnums.xlsx => DocumentEnums.xlsx,
                _ => throw new Exception("Error null search DocumentEnums")
            };
        }
    }
}
