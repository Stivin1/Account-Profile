using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.ModelControllers;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceGroup
{
    public interface IGroupService
    {
        public Task<int> CreateGroup(string UserId, string Name);

        public Task<IEnumerable<Groups>> GetListGroups();

        public Task<IEnumerable<UsersGroupsView>> GetUsersGroupsView();

        public Task<List<Groups>> GetSearchListUsersGroup(string UserId);

        public Task<int> AppendListUsersGroup(string UserId, string groups);

        public Task<int> DeleteListUsersGroup(string UserId, string groupss);
    }
}
