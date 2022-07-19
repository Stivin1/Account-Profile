using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys
{
    public class MessageSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("MessageId")]
        public int MessageId { get; set; }

        public Message Message { get; set; }

        public string UserId { get; set; }

        public string UserRecipientId { get; set; }

        public bool MessageDonorIsHidden { get; set; }

        public bool MessageRecipientIsHidden { get; set; }
    }
}
