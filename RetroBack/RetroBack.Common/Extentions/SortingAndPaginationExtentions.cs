using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Common.Extentions
{
    public static class SortingAndPaginationExtensions
    {

        public static IQueryable<T> SortAndPaginate<T>(this IQueryable<T> source, string sortBy, string sortDirection, int? skip, int? take)
        {
            source = source.OrderByField(sortBy, sortDirection);
            return source.Paginate(skip, take);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int? skip, int? take)
        {
            skip ??= 0;
            take ??= 20;

            return source.Skip(skip.Value).Take(take.Value);
        }
    }
}
