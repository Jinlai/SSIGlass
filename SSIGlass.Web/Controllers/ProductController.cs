using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Controllers
{
    using Contract.Services;
    using ViewModels;

    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult List([DefaultValue(1001)]int categoryId)
        {
            var model = new ProductListViewModel
                            {
                                CategoryId = categoryId,
                                Products = _productService.GetAll(categoryId)
                            };

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }
    }
}