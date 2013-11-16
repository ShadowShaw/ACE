using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Data;
using Core.Interfaces;

namespace ACEAgent.Controllers
{
    public class AdminController : Controller
    {
        private ACEContext db = new ACEContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modules()
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.ACEModules.GetAll().ToList());
            }
        }

        public ActionResult Payments()
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.Payments.GetAll().ToList());
            }
        }

        public string GetUserNameForId(int Id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return uow.Users.GetAll().Where(u => u.Id == Id).FirstOrDefault().UserName; 
            }
        }

        public string GetModuleNameForId(int Id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return uow.ACEModules.GetAll().Where(m => m.Id == Id).FirstOrDefault().Name;
            }
        }

        public ActionResult ModuleOrders()
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                return View(uow.ModuleOrders.GetAll().ToList());
            }
        }
      
        //
        // GET: /Admin/Create

        public ActionResult CreateModule()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreateModule(ACEModule acemodule)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    uow.ACEModules.Add(acemodule);
                    uow.Commit();
                }
                return RedirectToAction("Modules");
            }

            return View(acemodule);
        }

        //
        // GET: /Admin/Create

        public ActionResult CreatePayment()
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ViewBag.UserList = uow.Users.GetAll().ToList();
            }
            
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreatePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    UserProfile user = uow.Users.GetAll().Where(u => u.PaymentSymbol == payment.PaymentSymbol).FirstOrDefault();

                    uow.Payments.Add(payment);

                    user.Credit = user.Credit + payment.Amount;
                    uow.Users.Edit(user);

                    uow.Commit();
                    return RedirectToAction("Payments");
                }
            }

            return View(payment);
        }

        //
        // GET: /Admin/Create

        public ActionResult CreateModuleOrder()
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ViewBag.UserList = uow.Users.GetAll().ToList();
                ViewBag.ModuleList = uow.ACEModules.GetAll().ToList();
            }
            
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreateModuleOrder(ModuleOrder order)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    uow.ModuleOrders.Add(order);
                    uow.Commit();
                    return RedirectToAction("ModuleOrders");
                }
            }

            return View(order);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditModule(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ACEModule acemodule = uow.ACEModules.GetByID(id);
                if (acemodule == null)
                {
                    return HttpNotFound();
                }

                return View(acemodule);
            }
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditModule(ACEModule acemodule)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    uow.ACEModules.Edit(acemodule); // db.Entry(acemodule).State = EntityState.Modified;
                    uow.Commit();
                }
                return RedirectToAction("Modules");
            }
            return View(acemodule);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditPayment(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                Payment payment = uow.Payments.GetByID(id);
                ViewBag.UserList = uow.Users.GetAll().ToList();
                
                if (payment == null)
                {
                    return HttpNotFound();
                }

                return View(payment);
            }
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    uow.Payments.Edit(payment);
                    uow.Commit();
                }
                return RedirectToAction("Payments");
            }
            return View(payment);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditModuleOrder(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ModuleOrder order = uow.ModuleOrders.GetByID(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                
                ViewBag.UserList = uow.Users.GetAll().ToList();
                ViewBag.ModuleList = uow.ACEModules.GetAll().ToList();
                
                return View(order);
            }
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditModuleOrder(ModuleOrder order)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    uow.ModuleOrders.Edit(order);
                    uow.Commit();
                }
                return RedirectToAction("ModuleOrders");
            }
            return View(order);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult DeleteModule(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ACEModule acemodule = uow.ACEModules.GetByID(id);
                if (acemodule == null)
                {
                    return HttpNotFound();
                }

                return View(acemodule);
            }
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeleteModule")]
        public ActionResult DeleteModuleConfirmed(int id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ACEModule acemodule = uow.ACEModules.GetByID(id);
                uow.ACEModules.Delete(acemodule);
                uow.Commit();
                return RedirectToAction("Modules");
            }
        }

        public ActionResult DeletePayment(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                Payment payment = uow.Payments.GetByID(id);
                if (payment == null)
                {
                    return HttpNotFound();
                }
                return View(payment);
            }
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeletePayment")]
        public ActionResult DeletePaymentConfirmed(int id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                Payment payment = uow.Payments.GetByID(id);
                uow.Payments.Delete(payment);
                uow.Commit();
                return RedirectToAction("Payments");
            }
        }

        public ActionResult DeleteModuleOrder(int id = 0)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ModuleOrder order = uow.ModuleOrders.GetByID(id);
                if (order == null)
                {
                    return HttpNotFound();
                }

                ViewBag.UserId = order.UserId;
                ViewBag.ModuleId = order.ModuleId;

                return View(order);
            }
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeleteModuleOrder")]
        public ActionResult DeleteModuleOrderConfirmed(int id)
        {
            using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
            {
                ModuleOrder order = uow.ModuleOrders.GetByID(id);
                uow.ModuleOrders.Delete(order);
                uow.Commit();
                return RedirectToAction("ModuleOrders");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}