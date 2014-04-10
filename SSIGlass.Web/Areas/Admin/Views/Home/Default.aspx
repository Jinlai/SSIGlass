<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<DefaultViewModel>" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Management - Shanghai Star International Co.,LTD</title>
    <ext:ResourcePlaceHolder runat="server" />
    <link href="/Content/Styles/Admin/Ext-patch.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Styles/Admin/Comm.css" rel="stylesheet" type="text/css" />
    <script type="text/C#" runat="server">
        public void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            btnUserName.Text = Model.UserName;
            operationNavigation.Items.Add(Model.Navigation);
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server" ID="viewPort" Layout="BorderLayout">
        <Items>
            <ext:Toolbar runat="server" Region="North" Height="30" Margins="0 0 5 0">
                <Items>
                    <ext:Label runat="server" Cls="app-title" Text="Management - Shanghai Star International Co.,LTD" Icon="Application" Margins="12 0 0 0" />
                    <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    <ext:Button runat="server" ID="btnUserName" Icon="User" />
                    <ext:Button ID="Button1" runat="server" Text="退出登录" Icon="LockGo">
                        <DirectEvents>
                            <Click Url="/Admin/SignOut.aspx" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
            <ext:Panel runat="server" ID="operationNavigation" Region="West" Width="200" Margins="0 5 0 0" Layout="AccordionLayout" Title="操作导航" Collapsible="true" />
            <ext:TabPanel ID="tpMain" runat="server" Region="Center" EnableTabScroll="true" Frame="true">
                <Plugins>
                    <ext:TabCloseMenu runat="server" />
                </Plugins>
            </ext:TabPanel>
            <ext:Panel runat="server" Region="South" Cls="footer-copyright" Html="Shanghai Star International Co.,LTD &copy; 2003" Height="26" Margins="5 0 0 0" />
        </Items>
    </ext:Viewport>
    <script type="text/javascript">
        Ext.onReady(function() {
            Ext.ns("Egaplay.Ext");
            Egaplay.Ext = {
                hashCode: function (str) {
                    var hash = 1315423911;
                    for (var i = 0; i < str.length; i++) {
                        hash ^= ((hash << 5) + str.charCodeAt(i) + (hash >> 2));
                    }
                    return (hash & 0x7FFFFFFF);
                },                
                addTab: function(config) {
                    if (Ext.isEmpty(config.url, false)) return;
                    var tp = Ext.getCmp("tpMain");
                    var id = this.hashCode(config.url);
                    var tab = tp.getComponent(id);
                    if (!tab) {
                        tab = tp.addTab({
                                id: id.toString(),
                                title: config.title,
                                iconCls: config.icon || 'icon-applicationdouble',
                                closable: true,
                                autoLoad: {
                                    showMask: true,
                                    url: config.url,
                                    mode: 'iframe',
                                    noCache: true,
                                    maskMsg: "正在加载 " + config.title + "...",
                                    scripts: true,
                                    passParentSize: config.passParentSize
                                }
                            });
                    } else {
                        tp.setActiveTab(tab);
                        Ext.get(tab.tabEl).frame();
                    }
                }
            };
        }); 
    </script>
</body>
</html>