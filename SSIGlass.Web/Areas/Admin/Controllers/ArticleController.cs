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

    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        #region List
        public ActionResult List()
        {
            return View();
        }

        public ActionResult LoadArticleList()
        {
            var result = _articleService.GetAll();
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
        public ActionResult Add(Article model)
        {
            var result = new AjaxResult();
            try
            {
                model.Content = HttpUtility.UrlDecode(model.Content);
                model.UpdateTimestamp = DateTime.Now;
                _articleService.Create(model);
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
            var model = _articleService.GetById(articleId);
            return View(model);
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Article model)
        {
            var result = new AjaxResult();
            try
            {
                model.Content = HttpUtility.UrlDecode(model.Content);
                model.UpdateTimestamp = DateTime.Now;
                _articleService.Update(model);
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
                _articleService.Delete(articleId);
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