using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserForMessages;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserViewMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class MessageForUsers : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<AddresSent> AddresSents { get; set; }

        public ListUserForMessageFiltering ListUserForMessageFiltering { get; set; }

        public ListUserForMessagePagination ListUserForMessagePagination { get; set; }

        public ListUserForMessageSorting ListUserForMessageSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
