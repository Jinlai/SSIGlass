<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<PagingResult<UploadFileItem>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:#eee;">
<head>
    <title>FileUploadManage Default</title>
    <link href="/Content/Styles/Base.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .thumbnail {padding:3px;border:1px solid #aaa;margin:15px 0 0 15px;background-color: #ddd;}
        .thumbnail .img-wrap {width:100px;height:100px;}
        .thumbnail .links {text-align:center;}
        .thumbnail .links a {font:500 12px/22px Tahoma;color: blue;}
        .thumbnail .links a:hover {text-decoration:underline;color: #F60;}        
        /*分页*/
        .pager {margin-top:22px;height:22px;font:12px/15px Tahoma;}
        .pager a {padding:2px 7px;margin-left:6px;border:solid 1px #ccc;color:#4C5456;text-align:center;}
        .pager .pageCurrent {margin-left:6px;padding:2px 7px;color:#FD6D01;font-weight:bold;}
    </style>
</head>
<body style="background:none;">
    <iframe src="AjaxUploadPic.aspx" scrolling="no" width="100%" height="42" frameborder="0"></iframe>
    <div class="thumbnail fn-hide" style="height: auto;" id="imgPreViewBox">
        <label>图片预览:</label>
        <img src="" alt="图片预览" id="imgPreView" />
    </div>
    <div class="fn-clear">
    <%if (Model != null && Model.Items.Count > 0){%>
        <%foreach (var item in Model.Items){%>
        <div class="thumbnail fn-left">
            <div class="img-wrap" style="background:url(<%=Html.GraphicUrl(item.FileKey,100,100)%>) no-repeat center center;"></div>
            <div class="links">                
                <a href="javascript:void(0);" class="btn-copy" title="<%=item.FileKey%>">复制Key</a> <a href="javascript:;" id="<%=item.FileKey %>" class="del">删除</a>
            </div>
        </div>
        <%}%>
    <%}%>
    </div>
    <%var pagination = ViewData.Get<IPagination<UploadFileItem>>(); %>
    <%if (pagination != null && pagination.TotalPages > 1){%><div style="margin-top:15px;" class="pager fn-clear"><%=Html.Pager(pagination)%></div><%}%>    
    <script src="/Scripts/jQuery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/zclip/jquery.zclip.js" type="text/javascript"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $(".btn-copy").zclip({
                path: "/Scripts/zclip/ZeroClipboard.swf",
                copy: function() {
                    return $(this).attr("title");
                }
            });
            $(".del").click(function() {
                var self = $(this);
                if (confirm("确认要删除该图片吗?")) {
                    $.post("/Admin/FileUploadManage/Delete.aspx", { "fileKey": self.attr("id") }, function(status) {
                        if (status.IsSuccess)
                            self.parent().parent().remove();
                        else
                            alert(status.message);
                    });
                }
            });
        });
    </script>
</body>
</html>