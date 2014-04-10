<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Article>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=Model.Subject%><%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_英文")%>
    <%=Html.CustomContent("Banner_英文")%>
    <div class="ui-layout news-info">
        <h2>News</h2>
        <div style="padding-top:20px;">
            <em style="color: #aaa;"><%=Model.UpdateTimestamp.ToString("yyyy-MM-dd") %></em>
            <div class="fn-clear" style="border-bottom:1px dashed #ccc;">
                <h2 class="fn-left" style="margin-top:0;padding:3px 0 10px; color: #257cb8;font-size:17px;"><%=Model.Subject %></h2>
                <a class="fn-right" style="margin-top:4px;width:85px;height:30px;background:url(/Content/Images/back-news-list.jpg) no-repeat 0 0;" href="<%=Url.Action("List","News") %>"></a>
            </div>            
            <div style="margin-top:20px;text-align:center;">
                <%if(!String.IsNullOrEmpty(Model.PhotoKey)){%>
                    <img src="<%=Html.GraphicUrl(Model.PhotoKey) %>" alt="<%=Model.Subject %>" style="border:2px solid #C0C0C0;"/>
                <%}%>
            </div>
            <div style="margin-top:20px;">
                <%=Model.Content %>
            </div>
        </div>
    </div>
    <%=Html.CustomContent("Footer_英文")%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ui-nav a").eq(2).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>