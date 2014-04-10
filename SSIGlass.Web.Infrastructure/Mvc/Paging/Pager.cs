using System;
using System.Web;
using System.Text;
using System.Collections.Specialized;

namespace SSIGlass.Web.Infrastructure.Mvc.Paging
{
    using MvcContrib.Pagination;

    public class Pager
    {
        private readonly IPagination _pagination;
        protected IPagination Pagination
        {
            get { return _pagination; }
        }

        private readonly HttpRequestBase _request;
        protected HttpRequestBase Request
        {
            get { return _request; }
        }

        private Func<int, string> _urlBuilder;
        private Func<string, string, string> _tagBuilder;
        private Func<int, string> _currentPageNumberBuilder;

        // text
        private string _paginationFirst = "首页";
        private string _paginationPrev = "上一页";
        private string _paginationNext = "下一页";
        private string _paginationLast = "尾页";
        private string _pageQueryName = "page";

        private int _maxDisplayNumber = 5;

        public Pager(IPagination pagination, HttpRequestBase request)
        {
            _pagination = pagination;
            _request = request;

            _urlBuilder = CreateDefaultUrl;
            _tagBuilder = CreateDefaultTag;
            _currentPageNumberBuilder = CreateDefaultCurrentPageNumber;
        }

        /// <summary>
        /// 查询字段 默认是 'page'
        /// </summary>
        public Pager QueryParam(string queryStringParam)
        {
            _pageQueryName = queryStringParam;
            return this;
        }

        /// <summary>
        /// '首页'链接文字
        /// </summary>
        public Pager First(string first)
        {
            _paginationFirst = first;
            return this;
        }

        /// <summary>
        /// '上一页'链接文字
        /// </summary>
        public Pager Previous(string previous)
        {
            _paginationPrev = previous;
            return this;
        }

        /// <summary>
        /// '下一页'链接文字
        /// </summary>
        public Pager Next(string next)
        {
            _paginationNext = next;
            return this;
        }

        /// <summary>
        /// '尾页'链接文字
        /// </summary>
        public Pager Last(string last)
        {
            _paginationLast = last;
            return this;
        }

        /// <summary>
        /// 设置要显示的页码数量，
        /// 默认是5
        /// </summary>
        public Pager Display(int display)
        {
            _maxDisplayNumber = display;
            return this;
        }

        /// <summary>
        /// 设置生成URL的函数
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Pager UrlBuilder(Func<int, string> func)
        {
            _urlBuilder = func;
            return this;
        }

        /// <summary>
        /// 设置生成html标签的函数
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Pager TagBuilder(Func<string, string, string> func)
        {
            _tagBuilder = func;
            return this;
        }

        public Pager CurrentPageBuilder(Func<int, string> func)
        {
            _currentPageNumberBuilder = func;
            return this;
        }

        /// <summary>
        /// 返回分页html
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_pagination.TotalPages < 2)
                return null;

            var sb = new StringBuilder();

            RenderBegin(sb);
            RenderBody(sb);
            RenderEnd(sb);

            return sb.ToString();
        }

        protected virtual void RenderBegin(StringBuilder sb)
        {
            if (_pagination.PageNumber == 1)
                return;

            // 首页
            sb.Append(_tagBuilder(_urlBuilder(1), _paginationFirst));

            // 上一页
            sb.Append(_tagBuilder(_urlBuilder(_pagination.PageNumber - 1), _paginationPrev));
        }

        protected virtual void RenderBody(StringBuilder sb)
        {
            var currentPage = _pagination.PageNumber;

            // 当前页位置
            var cpl = (_maxDisplayNumber % 2 == 0) ? _maxDisplayNumber / 2 : (_maxDisplayNumber - 1) / 2;

            // 先计算出预想中分页起始的页码
            var begin = currentPage - cpl;
            if (begin < 1)
            {
                begin = 1;
            }

            // 根据起始号码计算结尾号码
            var end = begin + _maxDisplayNumber - 1;

            // 如果结尾页码超出总页数，那么结尾页码就是总页数
            // 并且根据要显示的页码数量重新计算起始页码
            if (end > _pagination.TotalPages)
            {
                end = _pagination.TotalPages;
                var d = end - begin;
                if (d < (_maxDisplayNumber - 1))
                {
                    var n = begin - (_maxDisplayNumber - 1 - d);
                    begin = n < 1 ? 1 : n;
                }
            }

            for (var i = begin; i <= end; i++)
            {
                sb.Append(i == currentPage ? _currentPageNumberBuilder(i) : _tagBuilder(_urlBuilder(i), i.ToString()));
            }
        }

        protected virtual void RenderEnd(StringBuilder sb)
        {
            if (_pagination.PageNumber == _pagination.TotalPages)
                return;

            // 下一页
            sb.Append(_tagBuilder(_urlBuilder(_pagination.PageNumber + 1), _paginationNext));

            // 尾页
            sb.Append(_tagBuilder(_urlBuilder(_pagination.TotalPages), _paginationLast));
        }


        private string CreateDefaultUrl(int page)
        {
            var queryString = CreateQueryString(_request.QueryString);
            var filePath = _request.FilePath;
            var url = string.Format("{0}?{1}={2}{3}", filePath, _pageQueryName, page, queryString);
            return url;
        }

        private static string CreateDefaultTag(string url, string text)
        {
            return string.Format("<a href=\"{0}\" class=\"fn-left\">{1}</a>", url, text);
        }

        private static string CreateDefaultCurrentPageNumber(int page)
        {
            return string.Format("<a class=\"pageCurrent fn-left\">{0}</a>", page);
        }

        /// <summary>
        /// MvcContrib.UI.Pager.Pager
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private string CreateQueryString(NameValueCollection values)
        {
            var builder = new StringBuilder();

            foreach (string key in values.Keys)
            {
                if (key == _pageQueryName)
                //Don't re-add any existing 'page' variable to the querystring - this will be handled in CreatePageLink.
                {
                    continue;
                }

                var strings = values.GetValues(key);
                if (strings != null)
                {
                    foreach (var value in strings)
                    {
                        builder.AppendFormat("&amp;{0}={1}", key, HttpUtility.UrlEncode(value));
                    }
                }
            }

            return builder.ToString();
        }
    }
}