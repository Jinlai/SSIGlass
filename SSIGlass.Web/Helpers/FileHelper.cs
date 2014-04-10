using System;
using System.Web.Mvc;

namespace SSIGlass.Web.Helpers
{
    using Contract.Services;
    using Microsoft.Practices.ServiceLocation;

    public static class FileHelper
    {
        private static readonly IGraphicViewService GraphicViewService = ServiceLocator.Current.GetInstance<IGraphicViewService>();

        public static string GetGraphicUrl(string fileKey)
        {
            return GetGraphicUrl(fileKey, null);
        }

        public static string GetGraphicUrl(string fileKey, string emptyUrl)
        {
            return GetGraphicUrl(fileKey, 0, 0, emptyUrl);
        }

        public static string GetGraphicUrl(string fileKey, int width, int height)
        {
            return GetGraphicUrl(fileKey, width, height, null);
        }

        public static string GetGraphicUrl(string fileKey, int width, int height, string emptyUrl)
        {
            string url;
            if (!String.IsNullOrEmpty(fileKey))
            {
                if (width == 0 && height == 0)
                    url = GraphicViewService.GetUrl(fileKey);
                else
                    url = GraphicViewService.GetUrl(fileKey, width, height);
            }
            else
            {
                url = emptyUrl;
            }
            return url;
        }

        public static MvcHtmlString GraphicUrl(this HtmlHelper html, string fileKey)
        {
            return GraphicUrl(html, fileKey, null);
        }

        public static MvcHtmlString GraphicUrl(this HtmlHelper html, string fileKey, string emptyUrl)
        {
            return GraphicUrl(html, fileKey, 0, 0, emptyUrl);
        }

        public static MvcHtmlString GraphicUrl(this HtmlHelper html, string fileKey, int width, int height)
        {
            return GraphicUrl(html, fileKey, width, height, null);
        }

        public static MvcHtmlString GraphicUrl(this HtmlHelper html, string fileKey, int width, int height, string emptyUrl)
        {
            var url = GetGraphicUrl(fileKey, width, height, emptyUrl);
            return MvcHtmlString.Create(url);
        }
    }
}