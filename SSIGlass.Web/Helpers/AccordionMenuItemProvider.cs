using System;
using System.Xml.Linq;

namespace SSIGlass.Web.Helpers
{
    using Ext.Net;
    using EgaplayFx.Core.IO.Content;

    public class AccordionMenuItemProvider
    {
        private readonly string _configFile;
        private readonly IContentProvider _contentProvider;

        public AccordionMenuItemProvider(string configFile)
        {
            _configFile = configFile;
            _contentProvider = new LocalStorageContentProvider();
        }

        /// <summary>
        /// 从配置文件中加载菜单
        /// </summary>
        public AccordionLayout GetMenu()
        {
            var accordionLayout = new AccordionLayout(new AccordionLayout.Config { Animate = true, CollapseFirst = true });
            if (String.IsNullOrEmpty(_configFile))
                throw new Exception("the path can not be null");

            var doc = XElement.Parse(_contentProvider.GetAllText(_configFile));
            var menus = doc.Descendants("menu");
            foreach (var menu in menus)
            {
                var menuPanel = new MenuPanel(new MenuPanel.Config { Title = menu.Attribute("title").Value });
                foreach (var submenu in menu.Descendants("submenu"))
                {
                    var menuItem = new MenuItem
                                       {
                                           Text = submenu.Attribute("title").Value,
                                           Icon = (Icon)(Convert.ToInt32(submenu.Attribute("icon").Value))
                                       };

                    menuItem.CustomConfig.Add(new ConfigItem
                                                  {
                                                      Name = "url",
                                                      Value = submenu.Attribute("url").Value,
                                                      Mode = ParameterMode.Value
                                                  });

                    menuPanel.Menu.Items.Add(menuItem);
                }
                menuPanel.Menu.Listeners.Click.Handler = "Egaplay.Ext.addTab({ title: menuItem.text, url: menuItem.url, icon: menuItem.iconCls });";
                accordionLayout.Items.Add(menuPanel);
            }
            return accordionLayout;
        }
    }
}