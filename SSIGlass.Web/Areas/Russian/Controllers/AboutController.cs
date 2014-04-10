using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Russian.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Distributor()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}