using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Controllers
{
    using Contract.Services;

    public class NewsController : Controller
    {
        //
        // GET: /News/
        private readonly IArticleService _aritcleService;
        public NewsController(IArticleService articleService)
        {
            _aritcleService = articleService;
        }

        public ActionResult List()
        {
            var result = _aritcleService.GetAll();
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var model = _aritcleService.GetById(id);
            return View(model);
        }
    }
}