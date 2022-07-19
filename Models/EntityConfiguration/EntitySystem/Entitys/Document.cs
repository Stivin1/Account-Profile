using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Name { get; set; }

        public byte[] Text { get; set; }

        public string DateCreate { get; set; }

        public bool IsDeleted { get; set; }

        public string DateDeleted { get; set; }

        [ForeignKey("RoleId")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("DocumentTypeId")]
        public int DocumentTypeId { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
