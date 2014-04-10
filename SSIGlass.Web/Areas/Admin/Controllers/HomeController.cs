using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin.Controllers
{    
    using ViewModels;
    using Helpers;

    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        private readonly AccordionMenuItemProvider _accordionMenuItemProvider;
        public HomeController(AccordionMenuItemProvider accordionMenuItemProvider)
        {
            _accordionMenuItemProvider = accordionMenuItemProvider;
        }
        public ActionResult Default()
        {
            var model = new DefaultViewModel
                            {
                                Navigation = _accordionMenuItemProvider.GetMenu()
                            };
            return View(model);
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}