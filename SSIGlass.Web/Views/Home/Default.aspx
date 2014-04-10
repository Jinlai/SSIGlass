<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Home<%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <meta name="keywords" content="Aluminium Spacer Bar for Insulating Glass, Warm Spacer Bar for IG, Molecular  Sieve 3A, Sealant for IG. Insulating Glass Material" />
    <meta name="description" content="Insulating Glass Material Supplier in china, Mainly Supply the Aluminium Spacer bar, warm Spacer bar, Molecular  Sieve 3A, Sealant for Insulating Glass. The famous company in Glass part." />
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_英文")%>
    <%=Html.CustomContent("Banner_英文")%>
    <%=Html.CustomContent("首页_英文")%>
    <div class="fn-clear" style="margin:35px auto 0;padding-bottom:25px;width:1000px;">
        <a class="fn-left" href="<%=Url.Action("Intro","About") %>" style="width:645px;height:235px;background:url(/Content/Images/home-about-bg.jpg) no-repeat 0 0;"></a>
        <div class="fn-left home-news-list">
            <img src="/Content/Images/home-news-title.jpg" alt="" />
            <%if(Model.Articles != null && Model.Articles.Count > 0){%>
            <ul>
                <%foreach(var article in Model.Articles){%>
                <li><a href="<%=Url.Action("Detail","News",new {id = article.ArticleId}) %>"><%=article.Subject %></a></li>
                <%}%>
            </ul>
            <div style="padding-top:10px;background:url(/Content/Images/home-news-list-bottom.jpg) no-repeat top center;">
                &nbsp;<a class="more" href="<%=Url.Action("List","News") %>">More info &gt;&gt;</a>
            </div>            
            <%}%>
        </div>
    </div>
    <%=Html.CustomContent("Footer_英文")%>
    <script type="text/javascript">
        $(document).ready(function() {
            $(".ui-nav a").eq(0).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>