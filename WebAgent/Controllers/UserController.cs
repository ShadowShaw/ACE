using System;
using System.Collections.Generic;
using System.Linq;
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

        public string GetModuleNameForId(int id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                if (uow.ACEModules.GetAll().Where(m => m.Id == id).Any())
                {
                    return uow.ACEModules.GetAll().Where(m => m.Id == id).FirstOrDefault().Name;    
                }
                else
                {
                    return "Modul již neexistuje";
                }
                
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

        public ActionResult OrdersList()
        {
            UserProfile currentUser = GetCurrentUser();
            ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
            ViewBag.Credit = currentUser.Credit;
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.ModuleOrders.GetAll().Where(u => u.UserId == currentUser.Id).ToList());
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
                ViewBag.PaymentSymbol = uow.Users.GetAll().Where(u => u.Id == currentUserId).FirstOrDefault().PaymentSymbol;
                List<ACEAgent.Models.ModuleOrders> viewModel = new List<ACEAgent.Models.ModuleOrders>();
                foreach (ACEModule module in ViewBag.Modules)
                {
                    ModuleOrders item = new ModuleOrders();
                    item.ModuleId = module.Id;
                    item.ModuleDescription = module.Description;
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
                    order.Price = moduleCost;
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

        public ActionResult ConfirmOrder(int moduleId)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ACEModule module = uow.ACEModules.GetByID(moduleId);
                ViewBag.ModuleName = module.Name;
                ViewBag.ModuleId = module.Id;
                UserProfile currentUser = GetCurrentUser();
                ViewBag.PaymentSymbol = currentUser.PaymentSymbol;
                ViewBag.Credit = currentUser.Credit;
                ViewBag.ModulePrice = module.MonthPrice;
                if (currentUser.Credit - module.MonthPrice >= 0)
                {
                    ViewBag.CreditAfterOrder = currentUser.Credit - module.MonthPrice;
                    ViewBag.CanOrder = true;
                }
                else
                {
                    ViewBag.CreditAfterOrder = "Pro objednání modulu nemáte dostatečný kredit";
                    ViewBag.CanOrder = false;
                }
            }
            return View();
        }

        public ActionResult MakeFacture(string paymentId)
        {
            PaymentFacture facture = new PaymentFacture();
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                Payment payment = uow.Payments.GetByID(Convert.ToInt32(paymentId));
                facture.FactureNumber = paymentId;
                facture.IssuerAddress = "Dvořákova 8, 602 00, Brno";
                facture.IssuerName = "Veronika Navrátilová";
                facture.IssueDate = payment.PaymentDate;
                facture.PaymentDate = payment.PaymentDate.AddMonths(1);
                //facture.FillingDate = "xxx";
                facture.Price = payment.Amount;
                UserProfile user = uow.Users.GetAll().SingleOrDefault(u => u.PaymentSymbol == payment.PaymentSymbol);
                facture.ReceiverAddress = user.FacturationAddress;
                facture.ReceiverName = user.FirstName + " " + user.LastName;
            }
            
            var pdf = new PdfResult(facture, "PdfFacture");

            pdf.ViewBag.Title = "Faktura - daňový doklad";

            return pdf;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}