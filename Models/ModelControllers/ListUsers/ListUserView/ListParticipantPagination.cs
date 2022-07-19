using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ListUsersView
{
    public class ListParticipantPagination
    {
        private int More { get; set; }

        public int CurrentPage { get; set; }

        public int CountPage { get; set; }

        public int TotalPage { get; set; }

        public int TotalItems { get; set; }

        public bool StartNumberPage { get; set; }

        public bool LastNumberPage { get; set; }

        public bool MorePage
        {
            get
            {
                return More > 5;
            }
        }

        public bool Bofore 
        { 
            get
            {
                return CurrentPage > 1;
            }

        }

        public bool After
        {
            get
            {
                return CurrentPage < TotalPage;
            }

        }
        public ListParticipantPagination(int CurrentPage, int CountPage, int TotalItems)
        {
            this.CurrentPage = CurrentPage;
            this.CountPage = CountPage;

            TotalPage = (int)Math.Ceiling(TotalItems / (double)CountPage);

            More = TotalPage;
        }
    }
}
