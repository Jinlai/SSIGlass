<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
    <script type="text/javascript">
        function submitForm() {
            if (AddForm.getForm().isValid()) {
                var parameters = AddForm.getForm().getValues();
                Ext.Ajax.request({
                        method: "post",
                        params: parameters,
                        url: "/Admin/Article/Add.aspx",
                        success: function(response) {
                            var result = Ext.util.JSON.decode(response.responseText);
                            if (result.IsSuccess) {
                                parent.Ext.Msg.alert("提示", "添加成功", function() {
                                    parent.reloadDataSource();
                                    parent.win.close("AddArticle");
                                });
                            }
                            else
                                parent.Ext.Msg.alert("提示", result.ErrorMessage);
                        }
                    });
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:FormPanel ID="AddForm" runat="server" IDMode="Static" BodyStyle="padding:15px 10px 10px;" LabelWidth="80" LabelAlign="Right">
        <Items>            
            <ext:TextField runat="server" ID="Subject" IDMode="Static" FieldLabel="标题" Width="300" AllowBlank="false" EmptyText="请输入文章标题" />
            <ext:TextField runat="server" ID="PhotoKey" IDMode="Static" FieldLabel="图片（可选）" Width="300" />
            <ext:TextArea runat="server" ID="Summary" IDMode="Static" FieldLabel="摘要" Width="300" />
            <ext:HtmlEditor runat="server" ID="Content" IDMode="Static" FieldLabel="文章内容" Width="525" Height="300" />
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="ApplicationFormAdd" Text="添 加">
                <Listeners>
                    <Click Handler="submitForm();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</body>
</html>