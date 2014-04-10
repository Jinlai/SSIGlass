using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin.Controllers
{
    using Contract.Services;
    using Infrastructure.Mvc.ActionResults;
    using Infrastructure.Mvc.Paging;
    using MvcContrib;

    /// <summary>
    /// 图片上传
    /// </summary>
    public class FileUploadManageController : Controller
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadManageController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public ActionResult Default([DefaultValue(1)]int page)
        {
            const int pageSize = 24;
            var result = _fileUploadService.GetAll(page, pageSize);
            if (result != null)
                ViewData.Add(result.Items.AsPagination(page, pageSize, result.TotalItems));

            return View(result);
        }

        #region 删除
        public ActionResult Delete(string fileKey)
        {
            var result = new AjaxResult();
            try
            {
                _fileUploadService.Delete(fileKey);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return Json(result);
        }
        #endregion

        #region  异步上传图片
        public virtual ActionResult AjaxUploadPic()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AjaxUploadPic(HttpPostedFileBase logoFileKey)
        {
            if (logoFileKey != null && logoFileKey.ContentLength > 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var retFileName = _fileUploadService.Save(logoFileKey.FileName.ToLower(), logoFileKey.ContentType, logoFileKey.InputStream);
                        ViewData["LogoFilePath"] = retFileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("LogoFileKey", ex.Message);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("LogoFileKey", "请选择您要上传的图片");
            }
            return View();
        }
        #endregion
    }
}