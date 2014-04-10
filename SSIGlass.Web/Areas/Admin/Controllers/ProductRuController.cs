using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin.Controllers
{
    using Contract.Services;
    using Contract;
    using Contract.Models;
    using Infrastructure.Mvc.ActionResults;

    public class ProductRuController : Controller
    {
        //
        // GET: /Admin/Product/
        private readonly IProductRuService _productRuService;
        public ProductRuController(IProductRuService productRuService)
        {
            _productRuService = productRuService;
        }

        #region List
        public ActionResult List()
        {
            return View();
        }

        public ActionResult LoadProductRuList()
        {
            var result = _productRuService.GetAll();
            var data = result.Select(x => new
                                              {
                                                  ProductId = x.ProductId,
                                                  CategoryName = ProductCategory.GetById(x.CategoryId).CategoryName,
                                                  ProductName = x.ProductName,
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
        public ActionResult Add(ProductRu model)
        {
            var result = new AjaxResult();
            try
            {
                model.Desc = HttpUtility.UrlDecode(model.Desc);
                model.UpdateTimestamp = DateTime.Now;
                _productRuService.Create(model);
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
        public ActionResult Edit(int productId)
        {
            var model = _productRuService.GetById(productId);
            return View(model);
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(ProductRu model)
        {
            var result = new AjaxResult();
            try
            {
                model.Desc = HttpUtility.UrlDecode(model.Desc);
                model.UpdateTimestamp = DateTime.Now;
                _productRuService.Update(model);
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
        public ActionResult Delete(int productId)
        {
            var result = new AjaxResult();
            try
            {
                _productRuService.Delete(productId);
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
