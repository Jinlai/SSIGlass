<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ArticleRu>" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit</title>
    <script type="text/C#" runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            ArticleId.Value = Model.ArticleId;
            Subject.Value = Model.Subject;
            PhotoKey.Value = Model.PhotoKey;
            Summary.Text = Model.Summary;
            Content.Value = Model.Content;
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:FormPanel ID="EditForm" runat="server" IDMode="Static" BodyStyle="padding:15px 10px 10px;" LabelWidth="80" LabelAlign="Right">
        <Items>
            <ext:Hidden runat="server" ID="ArticleId" IDMode="Static" />
            <ext:TextField runat="server" ID="Subject" IDMode="Static" FieldLabel="标题" Width="300" AllowBlank="false" EmptyText="请输入文章标题" />
            <ext:TextField runat="server" ID="PhotoKey" IDMode="Static" FieldLabel="图片（可选）" Width="300" />
            <ext:TextArea runat="server" ID="Summary" IDMode="Static" FieldLabel="摘要" Width="300" />
            <ext:HtmlEditor runat="server" ID="Content" IDMode="Static" FieldLabel="文章内容" Width="525" Height="300" />                        
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="ApplicationFormAdd" Text="修 改">
                <Listeners>
                    <Click Handler="submitForm();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
    <script type="text/javascript">
        function submitForm() {
            if (EditForm.getForm().isValid()) {
                var parameters = EditForm.getForm().getValues();
                Ext.Ajax.request({
                        method: "post",
                        params: parameters,
                        url: "/Admin/ArticleRu/Edit.aspx",
                        success: function(response) {
                            var result = Ext.util.JSON.decode(response.responseText);
                            if (result.IsSuccess) {
                                parent.Ext.Msg.alert("提示", "修改成功", function() {
                                    parent.reloadDataSource();
                                    parent.win.close("EditArticleRu" + parameters.ArticleId);
                                });
                            }
                            else {
                                parent.Ext.Msg.alert("提示", result.ErrorMessage);
                            }
                        }
                    });
            }
        }
    </script>
</body>
</html>