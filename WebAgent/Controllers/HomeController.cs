using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACEAgent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Automatická aktualizace cen eshopů.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakty:";

            return View();
        }
    }
}
