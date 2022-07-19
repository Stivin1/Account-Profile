using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class ListMessage : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<Participant> Participants { get; set; }

        public ListUserMessageFiltering ListUserMessageFiltering { get; set; }

        public ListUserMessagePagination ListUserMessagePagination { get; set; }

        public ListUserMessageSorting ListUserMessageSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
