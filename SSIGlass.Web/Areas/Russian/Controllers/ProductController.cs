using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Russian.Controllers
{
    using Contract.Services;
    using ViewModels;

    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private readonly IProductRuService _productRuService;
        public ProductController(IProductRuService productRuService)
        {
            _productRuService = productRuService;
        }

        public ActionResult List([DefaultValue(1001)]int categoryId)
        {
            var model = new ProductListRuViewModel
                            {
                                CategoryId = categoryId,
                                Products = _productRuService.GetAll(categoryId)
                            };

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var product = _productRuService.GetById(id);
            return View(product);
        }
    }
}