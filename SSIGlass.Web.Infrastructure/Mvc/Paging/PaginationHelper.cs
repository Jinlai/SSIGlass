using System.Collections.Generic;

namespace SSIGlass.Web.Infrastructure.Mvc.Paging
{
    using MvcContrib.Pagination;

    public static class PaginationHelper
    {
        public static IPagination<T> AsPagination<T>(this IEnumerable<T> source, int pageNumber, int pageSize, int total)
        {
            return new CustomPagination<T>(source, pageNumber, pageSize, total);
        }
    }
}