using System;
using System.Web.Mvc;

namespace SSIGlass.Web.Helpers
{
    using Contract.Services;
    using Microsoft.Practices.ServiceLocation;

    public static class CustomContentHelper
    {
        public static MvcHtmlString CustomContent(this HtmlHelper html, string key)
        {
            var service = ServiceLocator.Current.GetInstance<ICustomContentService>();
            var content = service.Get(key);
            return MvcHtmlString.Create(content);
        }

        public static MvcHtmlString CustomContent(this HtmlHelper html, string key, string defaultKey)
        {
            var service = ServiceLocator.Current.GetInstance<ICustomContentService>();
            var content = service.Get(key);
            if (String.IsNullOrEmpty(content))
                content = service.Get(defaultKey);
            return MvcHtmlString.Create(content);
        }
    }
}