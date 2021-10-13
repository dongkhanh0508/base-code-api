using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unikrowd.Bussiness.CommonModels;
using static Unikrowd.Data.Enums.CommonEnums;

namespace Unikrowd.Bussiness.Utils
{
    public static class Paging<T> where T : class
    {
        public static PagedResults<T> PagingAndSorting(IEnumerable<T> data, SortOrder sortOrder, string colName, int? index, int? size)

        {
            
            if (sortOrder == SortOrder.Ascending)
            {
                data = data.OrderBy(item => typeof(T).GetProperties().First(x => x.Name.Contains(colName, StringComparison.CurrentCultureIgnoreCase)).GetValue(item)).ToList();
            }
            else if (sortOrder == SortOrder.Descending)
            {
                data = data.OrderByDescending(item => typeof(T).GetProperties().First(x => x.Name.Contains(colName, StringComparison.CurrentCultureIgnoreCase)).GetValue(item)).ToList();
            }

            if (index != null && size != null)
            {
                index--;
                int skipCount = (int)(index * size);
                data = skipCount == 0 ? data.Take((int)size) : data.Skip(skipCount).Take((int)size).ToList();
            }
            

            int totalRecord = data.Count();
            var mod = totalRecord % size;
            var totalPageCount = (totalRecord / size) + (mod == 0 ? 0 : 1);
            return new PagedResults<T>
            {
                PageNumber = (int)(index + 1),
                PageSize = (int)size,
                TotalNumberOfPages = (int)totalPageCount,
                TotalNumberOfRecords = totalRecord,
                Results = data
            };
        }
    }
}
