<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/ExtNetBase.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ext:ResourceManager runat="server" />
    <ext:Store runat="server" ID="DataSourceStore" IDMode="Static">
        <Proxy>
            <ext:HttpProxy Json="true" Method="GET" Url="/Admin/ArticleRu/LoadArticleRuList.aspx" />
        </Proxy>
        <BaseParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={20}" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
                <Fields>
                    <ext:RecordField Name="ArticleId" />
                    <ext:RecordField Name="Subject" />
                    <ext:RecordField Name="UpdateTimestamp" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:GridPanel ID="DataGrid" runat="server" IDMode="Static" StoreID="DataSourceStore" TrackMouseOver="true" Region="Center" Margins="5 5 5 5">
                <ColumnModel>
                    <Columns>
                        <ext:Column DataIndex="ArticleId" Header="文章ID" Width="60" />
                        <ext:Column DataIndex="Subject" Header="标题" Width="400" />
                        <ext:Column DataIndex="UpdateTimestamp" Header="更新时间" Width="130" />
                        <ext:ImageCommandColumn Width="150">
                            <Commands>                                
                                <ext:ImageCommand Icon="TableEdit" Text="编辑" CommandName="Edit" /> 
                                <ext:ImageCommand Icon="Delete" Text="删除" CommandName="Delete" />
                            </Commands>
                        </ext:ImageCommandColumn>   
                    </Columns>
                </ColumnModel>
                <Listeners>
                    <Command Handler="operationCommand(command, record.data);" />
                </Listeners>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" ID="SelectedRow" />
                </SelectionModel>
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button Icon="Add" runat="server" Text="添加">
                                <Listeners>
                                    <Click Handler="win.show({ title: '文章信息添加', id: 'AddArticleRu', icon: 'icon-add', url: '/Admin/ArticleRu/Add.aspx' })" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script type="text/javascript">
        var win = new ExtNet.win();
        function reloadDataSource() {
            DataSourceStore.load();
        }
        function operationCommand(command, recordData) {
            var articleId = recordData.ArticleId;
            if (command == "Delete") {
                Ext.Msg.confirm("操作提示", "确定要删除该记录吗？", function(btnText) {
                    if (btnText == "yes") {
                        Ext.Ajax.request({
                                url: "/Admin/ArticleRu/Delete.aspx",
                                params: { articleId: articleId },
                                method: "post",
                                success: function(result) {
                                    var data = Ext.util.JSON.decode(result.responseText);
                                    if (data.IsSuccess)
                                        reloadDataSource();
                                    else
                                        Ext.Msg.alert("提示", data.ErrorMessage);
                                }
                            });
                    }
                });
            } else if (command == "Edit") {
                win.show({ title: '文章信息编辑', id: 'EditArticleRu' + articleId, icon: 'icon-tableedit', url: '/Admin/ArticleRu/Edit.aspx?articleId=' + articleId });
            }
        }
    </script>
</asp:Content>
