<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:#eee;">
<head>
    <title>AjaxUploadPic</title>
    <link href="/Content/Styles/Comm.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:none;">
<form action="<%=Url.Action("AjaxUploadPic","FileUploadManage") %>" method="post" enctype="multipart/form-data">
    <div class="form-row" style="margin:15px 0 0 15px;">
        <label style="font:500 14px/26px Tahoma;color:#333;">上传图片</label>
        <input type="file" id="LogoFileKey" name="LogoFileKey" style="height:26px;margin-left:5px;" />
        <input type="submit" id="btnSub" value="上 传" class="button" /><%=Html.ValidationMessage("LogoFileKey", new { style = "padding-left:26px;padding-right:5px;" })%>        
    </div>
</form>
<%if (ViewData["LogoFilePath"] != null) {%>
<script type="text/javascript">
    parent.location.href = parent.location.href;
</script>
<%}%>
</body>
</html>