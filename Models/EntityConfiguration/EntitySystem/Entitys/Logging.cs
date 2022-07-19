using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys
{
    public class Logging
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Description { get; set; }

        public string DateCreate { get; set; }

        public LoggingInformation loggingInformation { get; set; }

        [ForeignKey("LoggingInformationId")]
        public int LoggingInformationId { get; set; }

        public User User { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}
