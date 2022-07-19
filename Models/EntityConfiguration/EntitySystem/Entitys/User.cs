using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys
{
    public class User : IdentityUser
    {
        public Participant Profile { get; set; }

        public int Year { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public Country Country { get; set; }
        
        [ForeignKey("DomainId")]
        public int DomainId { get; set; }

        public Domains Domain { get; set; }

        public string DateCreate { get; set; }

        public string DateChanges { get; set; }

        public string DateLastEntry { get; set; }

        public bool ConsentProvisionPersonalData { get; set; }

        public virtual List<Groups> Groups { get; set; } = new List<Groups>();

        public virtual List<GroupsIntermediate> GroupsIntermediates { get; set; } = new List<GroupsIntermediate>();

        public virtual List<AddresSent> AddresSents { get; set; } = new List<AddresSent>();

        public virtual List<Document> Documents { get; set; } = new List<Document>();

        public List<Logging> Loggings { get; set; } = new List<Logging>();
    }
}
