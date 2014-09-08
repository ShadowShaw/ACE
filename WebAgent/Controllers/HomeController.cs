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

        public ActionResult HelpPage()
        {
            ViewBag.Message = "Nápověda:";

            return View();
        }


        public ActionResult Terms()
        {
            ViewBag.Message = "Obchodní podmínky:";

            return View();
        }

        public ActionResult Info()
        {
            ViewBag.Message = "Info:";

            return View();
        }

        public ActionResult Download()
        {
            ViewBag.Message = "Download:";

            return View();
        }
    }
}
