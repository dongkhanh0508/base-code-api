using System;
using System.Collections.Generic;
using System.Text;

namespace Unikrowd.Bussiness.CommonModels
{
    public static class CommonEnums
    {
        public enum Role
        {
            Admin = 1,
            Business = 2,
            Investor = 3,
        }
        public enum SortOrder
        {
            None = 0,
            Ascending = 1,
            Descending = 2,
        }
        public enum AccountStatus
        {
            All = 0,
            Active = 1,
            UnActive = 2,
            Deleted = 3
        }
    }
}
