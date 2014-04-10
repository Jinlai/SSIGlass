using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SSIGlass.Web.Helpers
{
    using EgaplayFx.Core.IO.Content;

    public class CustomContentMenuItemProvider
    {
        private readonly string _configFile;
        private readonly IContentProvider _contentProvider;

        public CustomContentMenuItemProvider(string configFile)
        {
            _configFile = configFile;
            _contentProvider = new LocalStorageContentProvider();
        }

        public string[] GetItems(string groupName)
        {
            var menuItems = _contentProvider.GetObject(_configFile, CreateObject);
            string[] items = null;
            if (menuItems.ContainsKey(groupName))
                items = menuItems[groupName];
            return items;
        }

        private static IDictionary<string, string[]> CreateObject(string content)
        {
            var menuItems = new Dictionary<string, string[]>();
            if (!String.IsNullOrEmpty(content))
            {
                var document = XDocument.Parse(content);
                var xElement = document.Element("groups");
                if (xElement != null)
                {
                    var groups = xElement.Elements("group");
                    foreach (var group in groups)
                    {
                        if (String.IsNullOrEmpty(group.Value)) continue;
                        var items = group.Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        var xAttribute = group.Attribute("name");
                        if (xAttribute != null) menuItems.Add(xAttribute.Value, items);
                    }
                }
            }
            return menuItems;
        }
    }
}