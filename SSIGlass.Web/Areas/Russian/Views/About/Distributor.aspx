<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>гудронатор<%=ConfigurationManager.AppSettings["html_title_suffix"]%></title>
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%=Html.CustomContent("Header_俄文")%>
    <%=Html.CustomContent("Banner_俄文")%>
    <%=Html.CustomContent("经销商页_俄文")%>
    <%=Html.CustomContent("Footer_俄文")%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ui-nav a").eq(4).css({ "color": "#257CB8" });
        });
    </script>
</body>
</html>