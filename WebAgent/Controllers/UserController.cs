using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Data;
using WebMatrix.WebData;
using ACEAgent.Models;
using RazorPDF;

namespace ACEAgent.Controllers
{
    public class UserController : Controller
    {
        private ACEContext db = new ACEContext();

        public ActionResult PaymentList()
        {
            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);
            UserProfile currentUser = db.UserProfiles.Where(u => u.Id == currentUserId).FirstOrDefault();
            ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
            ViewBag.Credit = currentUser.Credit;
            return View(db.Payments.Where(u => u.PaymentSymbol == currentUser.PaymentSymbol).ToList());
        }
        
        public ActionResult Index()
        {
            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);
            UserProfile currentUser = db.UserProfiles.Where(u => u.Id == currentUserId).FirstOrDefault();
            ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
            ViewBag.Credit = currentUser.Credit;
            
            return View(db.ModuleOrders.ToList());
        }

        public ActionResult OrderModule()
        {
            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.Modules = db.ACEModules.ToList();
            ViewBag.Credit = db.UserProfiles.Where(u => u.Id == currentUserId).FirstOrDefault().Credit;
            List<ACEAgent.Models.ModuleOrders> viewModel = new List<ACEAgent.Models.ModuleOrders>();
            foreach (ACEModule module in db.ACEModules.ToList())
            {
                ModuleOrders item = new ModuleOrders();
                item.ModuleId = module.Id;
                item.ModuleName = module.Name;
                item.MonthPrice = module.MonthPrice;
                
                List<ModuleOrder> orders = db.ModuleOrders.Where(u => u.UserId == currentUserId).Where(m => m.ModuleId == item.ModuleId).ToList();
                
                item.Active = false;
                item.OrderDate = null;

                foreach (ModuleOrder order in orders)
                {
                    if (order.OrderDate.AddDays(30) > DateTime.Now)
                    {
                        item.Active = true;
                        item.OrderDate = order.OrderDate.AddDays(30);
                    }
                }
                    
                viewModel.Add(item);
            }
            
            return View(viewModel);

        }

        public ActionResult MakeOrder(int moduleId)
        {
            UnitOfWorkProvider uowProvider = new UnitOfWorkProvider();
            var uow = uowProvider.CreateNew();

            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);
            UserProfile user = uow.Users.GetByID(currentUserId);

            decimal moduleCost = uow.ACEModules.GetAll().Where(m => m.Id == moduleId).FirstOrDefault().MonthPrice;

            if (user.Credit >= moduleCost)
            {
                user.Credit = user.Credit - moduleCost;
                uow.Users.Edit(user);

                ModuleOrder order = new ModuleOrder();
                order.ModuleId = moduleId;
                order.OrderDate = DateTime.Now;
                order.UserId = currentUserId;
                uow.ModuleOrders.Add(order);
                uow.Commit();
                ViewBag.StatusMessage = "Modul úspěšně objednán.";
                return RedirectToAction("OrderModule");

            }
            else
            {
                ViewBag.StatusMessage = "Nemáte dostatečný kredit pro aktivaci modulu. Dobijte si prosím kredit.";
                return RedirectToAction("OrderModule");
            }
        }

        public ActionResult MakeFacture(string id)
        {
            // Since type is an ActionResult, we can still return an html view if something isn't right
            PaymentFacture facture = new PaymentFacture();
            // pass in Model, then View name
            var pdf = new PdfResult(facture, "PdfFacture");

            // Add to the view bag
            pdf.ViewBag.Title = "Title from ViewBag";

            return pdf;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}