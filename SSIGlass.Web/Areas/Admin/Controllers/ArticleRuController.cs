using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin.Controllers
{
    using Contract;
    using Contract.Models;
    using Contract.Services;
    using Infrastructure.Mvc.ActionResults;

    public class ArticleRuController : Controller
    {
        //
        // GET: /Article/
        private readonly IArticleRuService _articleRuService;
        public ArticleRuController(IArticleRuService articleRuService)
        {
            _articleRuService = articleRuService;
        }

        #region List
        public ActionResult List()
        {
            return View();
        }

        public ActionResult LoadArticleRuList()
        {
            var result = _articleRuService.GetAll();
            var data = result.Select(x => new
                                              {
                                                  ArticleId = x.ArticleId,
                                                  Subject = x.Subject,
                                                  UpdateTimestamp = x.UpdateTimestamp.ToString("yyy-MM-dd HH:mm:ss")
                                              });
            return Json(new ExtPagingResult { Data = data, TotalRecords = result.Count }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(ArticleRu model)
        {
            var result = new AjaxResult();
            try
            {
                model.Content = HttpUtility.UrlDecode(model.Content);
                model.UpdateTimestamp = DateTime.Now;
                _articleRuService.Create(model);
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ErrorMessage = exception.Message;
            }

            return Json(result);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int articleId)
        {
            var model = _articleRuService.GetById(articleId);
            return View(model);
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(ArticleRu model)
        {
            var result = new AjaxResult();
            try
            {
                model.Content = HttpUtility.UrlDecode(model.Content);
                model.UpdateTimestamp = DateTime.Now;
                _articleRuService.Update(model);
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ErrorMessage = exception.Message;
            }
            return Json(result);
        }
        #endregion

        #region Delete
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int articleId)
        {
            var result = new AjaxResult();
            try
            {
                _articleRuService.Delete(articleId);
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ErrorMessage = exception.Message;
            }
            return Json(result);
        }
        #endregion
    }
}