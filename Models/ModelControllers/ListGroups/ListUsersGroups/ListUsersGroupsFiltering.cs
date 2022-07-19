using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListGroups.ListUsersGroups
{
    public class ListUsersGroupsFiltering
    {
        public IEnumerable<UsersGroupsView> UsersGroupsView { get; set; }

        public ListUsersGroupsFiltering(IEnumerable<UsersGroupsView> UsersGroupsView)
        {
            this.UsersGroupsView = UsersGroupsView;
        }

        public IEnumerable<UsersGroupsView> ListUsersGetFiltering(string Name, string DateCreate)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                UsersGroupsView = UsersGroupsView.Where(t => t.GroupName.Contains(Name));
            }

            if (!string.IsNullOrEmpty(DateCreate))
            {
                DateTime now = Convert.ToDateTime(DateCreate);

                string st1 = string.Format($"{now.ToString("g")}");


                UsersGroupsView = UsersGroupsView.Where(t => t.DateCreate != null).Where(t => t.DateCreate.Contains(st1));
            }

            return UsersGroupsView;
        }
    }
}
