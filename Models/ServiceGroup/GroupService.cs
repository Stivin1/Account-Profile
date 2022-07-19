using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.SystemStorage.StorageEntityContext.UnitOfWork;
using OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceGroup
{
    public class GroupService : IGroupService
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        public GroupService(IUnitOfWork UnitOfWork, EntitySourceContext EntitySourceContext)
        {
            this.EntitySourceContext = EntitySourceContext;
            this.UnitOfWork = UnitOfWork;
        }


        public Task<int> AppendUsersGroup(User user, string[] groups)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateGroup(string UserId, string Name)
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Error append group in user");

            Groups groups = new Groups
            {
                Name = Name,
            };

            EntitySourceContext.Groups.Add(groups);

            await EntitySourceContext.SaveChangesAsync();

            return await Task.FromResult(1);
        }

        public async Task<IEnumerable<Groups>> GetListGroups()
        {
            var groups = await UnitOfWork.RepositoryGroups.GetEntitys();

            return groups;
        }

        public async Task<List<Groups>> GetSearchListUsersGroup(string UserId)
        {
            var userteams = await EntitySourceContext.Groups.Include(t => t.GroupsIntermediates.ToList().Where(t => t.UserId == UserId))
                .ToListAsync();

            List<Groups> past = new List<Groups>();

            foreach(var list in userteams)
            {
                foreach(var list1 in list.GroupsIntermediates)
                {
                    if(list.id == list1.GroupsId)
                    {
                        past.Add(list);
                    }
                }
            }

            return past;
        }

        public async Task<int> AppendListUsersGroup(string UserId, string groups)
        {
            var userteams = await EntitySourceContext.Groups.Include(t => t.GroupsIntermediates).ToListAsync();

            foreach(var list in userteams)
            {
                if (list.Name == groups)
                {
                    var group = await EntitySourceContext.Groups.FirstOrDefaultAsync(t => t.Name == groups);
                    var item = await EntitySourceContext.GroupsIntermediates.FirstOrDefaultAsync(t => t.UserId == UserId && t.GroupsId == group.id);

                    if (item == null)
                    {
                        GroupsIntermediate groupsIntermediate = new GroupsIntermediate
                        {
                            UserId = UserId,
                            GroupsId = list.id,
                            DateCreate = DateTime.Now.ToString()
                        };

                        EntitySourceContext.Add(groupsIntermediate);
                        await EntitySourceContext.SaveChangesAsync();
                    }
                }
            }

            return 1;
        }

        public async Task<int> DeleteListUsersGroup(string UserId, string groups)
        {
            var userteams = await EntitySourceContext.Groups.Include(t => t.GroupsIntermediates).ToListAsync();

            List<string> result = new List<string>();

            foreach (var group in groups)
            {
                foreach (var setgroups in userteams)
                {
                    foreach (var GroupsIntermediate in setgroups.GroupsIntermediates.ToList())
                    {
                        if (setgroups.Name == groups)
                        {
                            setgroups.GroupsIntermediates.Remove(GroupsIntermediate);

                            await EntitySourceContext.SaveChangesAsync();
                        }
                    }
                }
            }; 

            return 1;
        }

        public async Task<IEnumerable<UsersGroupsView>> GetUsersGroupsView()
        {
            var groups = await EntitySourceContext.Groups.Include(t => t.GroupsIntermediates).Include(t => t.Users).ToListAsync();

            List<UsersGroupsView> UsersGroupsView = new List<UsersGroupsView>();

            foreach (var list in groups)
            {
                UsersGroupsView.Add
                (
                     new UsersGroupsView
                     {
                         GroupId = list.id,
                         GroupName = list.Name,
                         Count = EntitySourceContext.GroupsIntermediates.Where(t => t.GroupsId == list.id).ToListAsync().Result.Count(),
                         DateCreate = EntitySourceContext.GroupsIntermediates.Include(t => t.Groups)
                         .Where(t => t.GroupsId == list.id).Select(t => t.DateCreate).FirstOrDefaultAsync().Result
                     }
                );
            }

            return UsersGroupsView;
        }
    }
}
