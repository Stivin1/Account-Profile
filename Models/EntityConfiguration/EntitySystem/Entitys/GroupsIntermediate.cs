using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys
{
    public class GroupsIntermediate
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int GroupsId { get; set; }

        public Groups Groups { get; set; }

        public string DateCreate { get; set; }
    }
}
