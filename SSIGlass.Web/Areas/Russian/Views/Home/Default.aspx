<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>родина<%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <meta name="keywords" content="Алюминиевая дистанционная рамкадля стеклопакетов, Теплый бардля стеклопакетов, молекулярное сито, Сеалант стеклопакетов,  Герметик для стеклопакетов" />
    <meta name="description" content="Изоляционные Поставщик Материал Стекло в Китае, главным образом поставляем алюминиевые дистанционной рамки, теплый бар Spacer, Молекулярные сита 3А, Герметик для стеклопакета. Известная компания в стеклянной части." />
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_俄文")%>
    <%=Html.CustomContent("Banner_俄文")%>
    <%=Html.CustomContent("首页_俄文")%>
    <div class="fn-clear" style="margin:35px auto 0;padding-bottom:25px;width:1000px;">
        <a class="fn-left" href="<%=Url.Action("Intro", "About", new {Area = "Russian"}) %>" style="width:645px;height:235px;background:url(/Content/Images/home-about-bg-ru.jpg) no-repeat 0 0;"></a>
        <div class="fn-left home-news-list">
            <img src="/Content/Images/home-news-title-ru.jpg" alt="" />
            <%if(Model.Articles != null && Model.Articles.Count > 0){%>
            <ul>
                <%foreach(var article in Model.Articles){%>
                <li><a href="<%=Url.Action("Detail","News",new {Area = "Russian",id = article.ArticleId}) %>"><%=article.Subject %></a></li>
                <%}%>
            </ul>
            <div style="padding-top:10px;background:url(/Content/Images/home-news-list-bottom.jpg) no-repeat top center;">
                &nbsp;<a class="more" href="<%=Url.Action("List","News", new {Area = "Russian"}) %>">More info &gt;&gt;</a>
            </div>            
            <%}%>
        </div>
    </div>
    <%=Html.CustomContent("Footer_俄文")%>
    <script type="text/javascript">
        $(document).ready(function() {
            $(".ui-nav a").eq(0).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>