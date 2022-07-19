using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers.ListUsers.ListUserService;
using OpenSourceEntitys.Models.ModelControllers.ListUsersView;
using OpenSourceEntitys.Models.ModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers
{
    public class ListUser : IHelpersCountMessage
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public IEnumerable<Participant> Participants { get; set; }

        public ListParticipantFiltering ListUsersFiltering { get; set; }

        public ListParticipantPagination ListUsersPagination { get; set; }

        public ListParticipantSorting ListUsersSorting { get; set; }

        public int HelpersDisplayCountMessage { get; set; }

        public int HelpersDeletedCountMessage { get; set; }
    }
}
