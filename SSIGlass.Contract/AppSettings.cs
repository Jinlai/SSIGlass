using System;
using System.Configuration;

namespace SSIGlass.Contract
{
    public static class AppSettings
    {
        private const string EmptyPhoto = "empty_photo";

        public static string GetEmptyPhoto()
        {
            return GetValue<string>(EmptyPhoto);
        }

        public static T GetValue<T>(string key)
        {
            var result = default(T);
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                result = (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            { }
            return result;
        }
    }
}