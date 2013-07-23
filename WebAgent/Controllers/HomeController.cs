using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceUpdater.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Automatická aktualizace cen eshopů.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplikace sloužící ke snadné a rychlé kontrole konzistence databáze eshopů a její přečeňování dle ceníků dodavatelů.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakty:";

            return View();
        }
    }
}
