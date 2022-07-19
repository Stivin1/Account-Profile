using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups
{
    public class ListUsersGroupsSorting
    {
        public enum UsersGroupsSorting
        {
            NameAsc,
            NameDesc,
            DateCreateAsc,
            DateCreateDesc,
        }

        public UsersGroupsSorting Name;

        public UsersGroupsSorting DateCreate;

        public UsersGroupsSorting Default;

        public ListUsersGroupsSorting(UsersGroupsSorting UsersGroupsSorting)
        {
            Default = UsersGroupsSorting;

            Name = UsersGroupsSorting == UsersGroupsSorting.NameAsc ? UsersGroupsSorting.NameDesc : UsersGroupsSorting.NameAsc;

            DateCreate = UsersGroupsSorting == UsersGroupsSorting.DateCreateAsc ? UsersGroupsSorting.DateCreateDesc : UsersGroupsSorting.DateCreateAsc;
        }

        public IEnumerable<UsersGroupsView> GetListUsersGroupsSorting(IEnumerable<UsersGroupsView> GroupsIntermediates, UsersGroupsSorting UsersGroupsSorting)
        {
            switch (UsersGroupsSorting)
            {
                case UsersGroupsSorting.NameAsc:
                    GroupsIntermediates = GroupsIntermediates.OrderBy(t => t.GroupName);
                    break;
                case UsersGroupsSorting.NameDesc:
                    GroupsIntermediates = GroupsIntermediates.OrderByDescending(t => t.GroupName);
                    break;
                case UsersGroupsSorting.DateCreateAsc:
                    GroupsIntermediates = GroupsIntermediates.OrderBy(t => t.DateCreate);
                    break;
                case UsersGroupsSorting.DateCreateDesc:
                    GroupsIntermediates = GroupsIntermediates.OrderByDescending(t => t.DateCreate);
                    break;
                default: throw new Exception("Error null search element in UsersGroupsSorting");
            }

            return GroupsIntermediates;
        }
    }
}
