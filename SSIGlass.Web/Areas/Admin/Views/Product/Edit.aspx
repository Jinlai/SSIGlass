﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Product>" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit</title>
    <script type="text/C#" runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            cbCategory.Items.AddRange(ProductCategory.AllCategories.Select(x => new Ext.Net.ListItem { Text = x.CategoryName, Value = x.CategoryId.ToString(CultureInfo.InvariantCulture) }));
            ProductId.Value = Model.ProductId;
            ProductName.Value = Model.ProductName;
            PhotoKey.Value = Model.PhotoKey;
            Desc.Text = Model.Desc;
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:FormPanel ID="EditForm" runat="server" IDMode="Static" BodyStyle="padding:15px 10px 10px;" LabelWidth="85" LabelAlign="Right">
        <Items>
            <ext:Hidden runat="server" ID="ProductId" IDMode="Static" />
            <ext:ComboBox ID="cbCategory" HiddenValue="CategoryId" HiddenName="CategoryId" IDMode="Static" runat="server" Mode="Local" FieldLabel="Category" AllowBlank="false" />            
            <ext:TextField runat="server" ID="ProductName" IDMode="Static" FieldLabel="Product Name" Width="300" AllowBlank="false" />
            <ext:TextField runat="server" ID="PhotoKey" IDMode="Static" FieldLabel="Product Photo" Width="300" />            
            <ext:HtmlEditor runat="server" ID="Desc" IDMode="Static" FieldLabel="Product Desc" Width="525" Height="300" />                      
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
                    url: "/Admin/Product/Edit.aspx",
                    success: function(response) {
                        var result = Ext.util.JSON.decode(response.responseText);
                        if (result.IsSuccess) {
                            parent.Ext.Msg.alert("提示", "修改成功", function() {
                                parent.reloadDataSource();
                                parent.win.close("EditProduct" + parameters.ProductId);
                            });
                        } else {
                            parent.Ext.Msg.alert("提示", result.ErrorMessage);
                        }
                    }
                });
            }
        }

        Ext.onReady(function() {
            parent.Ext.getBody().unmask();
            Ext.getCmp("cbCategory").setValue("<%=Model.CategoryId%>");
        });
    </script>
</body>
</html>