<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Product>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=Model.ProductName %><%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_英文")%>
    <%=Html.CustomContent("Banner_英文")%>
    <div class="ui-layout product-info fn-clear">
        <div class="fn-left cate">
            <ul>
                <li><a href="<%=Url.Action("List","Product",new {categoryId =  1001}) %>"<%if(Model.CategoryId == 1001){%> style="color:#257CB8;"<%}%>>Aluminium Spacer Bar</a></li>
                <li><a href="<%=Url.Action("List","Product",new {categoryId =  1002}) %>"<%if(Model.CategoryId == 1002){%> style="color:#257CB8;"<%}%>>Warm Spacer Bar</a></li>
                <li><a href="<%=Url.Action("List","Product",new {categoryId =  1003}) %>"<%if(Model.CategoryId == 1003){%> style="color:#257CB8;"<%}%>>Molecular Sieve</a></li>
                <li><a href="<%=Url.Action("List","Product",new {categoryId =  1004}) %>"<%if(Model.CategoryId == 1004){%> style="color:#257CB8;"<%}%>>Sealant for IG</a></li>
            </ul>
        </div>
        <div class="fn-left product-detail">
            <h2><%=Model.ProductName %></h2>
            <div class="img">
                <img src="<%=Html.GraphicUrl(Model.PhotoKey) %>" style="width:516px;height:384px;" alt="<%=Model.ProductName %>" />
            </div>
            <div class="content">
                <%=Model.Desc %>
            </div>
        </div>
    </div>
    <%=Html.CustomContent("Footer_英文")%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ui-nav a").eq(3).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>