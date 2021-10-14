using System;
using System.Collections.Generic;
using System.Text;
using static Unikrowd.Bussiness.CommonModels.CommonEnums;

namespace Unikrowd.Bussiness.CommonModels
{
    public class PagedResults<T>
    {
        /// <summary>
        /// The page number this page represents.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The size of this page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of pages available.
        /// </summary>
        public int TotalNumberOfPages { get; set; }

        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int TotalNumberOfRecords { get; set; }

        /// <summary>
        /// The URL to the next page - if null, there are no more pages.
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
    public class PagingRequest
    {
        public int? Page { get; set; } = null;
        public int? PageSize { get; set; } = null;
        public string KeySearch { get; set; } = "";
        public SortOrder SortType { get; set; } = SortOrder.None;
        public string ColName { get; set; } = "Id";
    }
}
