using System.Collections.Generic;
using System.Web.Mvc;

namespace SSIGlass.Web.Infrastructure.Mvc.Paging
{
    using MvcContrib;

    public static class ViewDataExtensions
    {
        public static T GetOrDefault<T>(this IDictionary<string, object> bag)
        {
            return bag.GetOrDefault(default(T));
        }
        public static T GetOrDefault<T>(this ViewDataDictionary bag)
        {
            return bag.GetOrDefault(default(T));
        }

        public static T GetOrDefault<T>(this IDictionary<string, object> bag, T defaultValue)
        {
            return bag.Contains<T>() ? bag.Get<T>() : defaultValue;
        }

        public static T GetOrDefault<T>(this ViewDataDictionary bag, T defaultValue)
        {
            return bag.Contains<T>() ? bag.Get<T>() : defaultValue;
        }
    }
}