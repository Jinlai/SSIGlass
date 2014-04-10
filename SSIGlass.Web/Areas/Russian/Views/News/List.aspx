<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IList<ArticleRu>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>известие<%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_俄文")%>
    <%=Html.CustomContent("Banner_俄文")%>
    <div class="ui-layout news-list-info">
        <h2>известие</h2>
        <%if(Model != null && Model.Count > 0){%>
        <ul>
            <%foreach(var article in Model){%>
            <li class="fn-clear">
                <div class="fn-left news-img">
                    <%if(!String.IsNullOrEmpty(article.PhotoKey)){%><img src="<%=Html.GraphicUrl(article.PhotoKey) %>" style="width:181px;height:126px;" alt="<%=article.Subject %>" /><%}%>
                </div>
                <div class="fn-left news-summary">
                    <em><%=article.UpdateTimestamp.ToString("yyyy-MM-dd") %></em>
                    <h3><a href="<%=Url.Action("Detail","News",new {Area = "Russian",id = article.ArticleId}) %>" target="_blank"><%=article.Subject %></a></h3>
                    <p><%=article.Summary %></p>
                    <h4><a href="<%=Url.Action("Detail","News",new {Area = "Russian",id = article.ArticleId}) %>" target="_blank">Подробнее</a></h4>
                </div>
            </li>
            <%}%>
        </ul>
        <%}%>
    </div>
    <%=Html.CustomContent("Footer_俄文")%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ui-nav a").eq(2).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>