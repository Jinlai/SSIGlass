<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/ExtNetBase.Master" Inherits="System.Web.Mvc.ViewPage<CustomContentViewModel>" %>
<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<script type="text/C#" runat="server">
    protected  void Page_Load(object sender,EventArgs e)
    {
        if (Model == null) return;
        GroupName.Text = Model.GroupName;
        Key.Text = Model.Key;
        Content.Text = Model.Content;
    }
</script>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:FormPanel ID="ContentForm" IDMode="Static" runat="server" Frame="true" Width="1012">
        <Items>
            <ext:Hidden ID="GroupName" IDMode="Static" runat="server" HideLabel="true" />
            <ext:Hidden ID="Key" IDMode="Static" runat="server" HideLabel="true" />
            <ext:HtmlEditor ID="Content" IDMode="Static" runat="server" Height="500" Width="1000" HideLabel="true" />
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="TableSave" Text="保存修改">
                <Listeners>
                    <Click Handler="submitForm();" />
                </Listeners>
            </ext:Button>        
        </Buttons>
    </ext:FormPanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="Footer">
    <script type="text/javascript">
        function submitForm() {
            var parameters = ContentForm.getForm().getValues();
            Ext.Ajax.request({
                method: "post",
                url: "/Admin/CustomContent/Edit.aspx",
                params: parameters,
                success: function (response) {
                    var result = Ext.util.JSON.decode(response.responseText);
                    if (result.IsSuccess)
                        Ext.Msg.alert("提示", "编辑成功 ");
                },
                failure: function (response) {
                    var result = Ext.util.JSON.decode(response.responseText);
                    Ext.Msg.alert("提示", result.ErrorMessage);
                }
            });
        }
    </script>
</asp:Content>