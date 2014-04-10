using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Controllers
{
    using Contract.Services;
    using ViewModels;

    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IArticleService _articleService;
        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ActionResult Default()
        {
            var model = new HomeViewModel
                            {
                                Articles = _articleService.GetAll().OrderByDescending(x => x.UpdateTimestamp).Take(4).ToList()
                            };

            return View(model);
        }
    }
}