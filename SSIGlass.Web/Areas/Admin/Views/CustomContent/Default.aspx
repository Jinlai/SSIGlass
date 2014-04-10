<%@ Page Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/ExtNetBase.Master" Inherits="System.Web.Mvc.ViewPage<CustomContentViewModel>" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<script type="text/C#" runat="server">
    protected void Page_Load(object sender,EventArgs e)
    {
        foreach (var item in Model.Items)
        {
            if (String.IsNullOrEmpty(item)) continue;
            var panel = new Ext.Net.Panel {Title = item};
            panel.AutoLoad.ShowMask = true;
            panel.AutoLoad.Url = Url.Action("Edit", "CustomContent", new {groupName = Model.GroupName, key = item});
            panel.AutoLoad.Mode = LoadMode.IFrame;
            ContentPanel.Items.Add(panel);
        }        
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:TabPanel runat="server" ID="ContentPanel" IDMode="Static" Frame="true" Height="500" />
        </Items>
    </ext:Viewport>
</asp:Content>