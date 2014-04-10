using System.Web.Mvc;

namespace SSIGlass.Web.Infrastructure.Mvc.Paging
{
    using MvcContrib.Pagination;

    public static class PaginationExtensions
    {
        public static Pager Pager(this HtmlHelper helper, IPagination pagination)
        {
            return new Pager(pagination, helper.ViewContext.HttpContext.Request);
        }
    }
}