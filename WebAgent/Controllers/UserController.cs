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
using Core.Interfaces;

namespace ACEAgent.Controllers
{
    public class UserController : Controller
    {
        private ACEContext db = new ACEContext();

        private UserProfile GetCurrentUser()
        {
            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);

            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                UserProfile currentUser = uow.Users.GetAll().Where(u => u.Id == currentUserId).FirstOrDefault();
                return currentUser;
            }
        }

        public ActionResult PaymentList()
        {
            UserProfile currentUser = GetCurrentUser();
            ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
            ViewBag.Credit = currentUser.Credit;
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.Payments.GetAll().Where(u => u.PaymentSymbol == currentUser.PaymentSymbol).ToList());
            }
        }
        
        public ActionResult Index()
        {
            UserProfile currentUser = GetCurrentUser();
            ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
            ViewBag.Credit = currentUser.Credit;
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.ModuleOrders.GetAll().ToList());
            }
        }

        public ActionResult OrderModule()
        {
            int currentUserId = WebSecurity.GetUserId(User.Identity.Name);
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ViewBag.Modules = uow.ACEModules.GetAll().ToList();
                ViewBag.Credit = uow.Users.GetAll().Where(u => u.Id == currentUserId).FirstOrDefault().Credit;
                List<ACEAgent.Models.ModuleOrders> viewModel = new List<ACEAgent.Models.ModuleOrders>();
                foreach (ACEModule module in ViewBag.Modules)
                {
                    ModuleOrders item = new ModuleOrders();
                    item.ModuleId = module.Id;
                    item.ModuleName = module.Name;
                    item.MonthPrice = module.MonthPrice;

                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == currentUserId).Where(m => m.ModuleId == item.ModuleId).ToList();

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
        }

        public ActionResult MakeOrder(int moduleId)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
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
        }

        public ActionResult MakeFacture(string id)
        {
            PaymentFacture facture = new PaymentFacture();
            var pdf = new PdfResult(facture, "PdfFacture");

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