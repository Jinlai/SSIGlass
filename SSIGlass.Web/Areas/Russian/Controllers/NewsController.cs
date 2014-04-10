using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Russian.Controllers
{
    using Contract.Services;

    public class NewsController : Controller
    {
        //
        // GET: /News/
        private readonly IArticleRuService _aritcleRuService;
        public NewsController(IArticleRuService articleRuService)
        {
            _aritcleRuService = articleRuService;
        }

        public ActionResult List()
        {
            var result = _aritcleRuService.GetAll();
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var model = _aritcleRuService.GetById(id);
            return View(model);
        }
    }
}