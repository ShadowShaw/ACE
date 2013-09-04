using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Data;

namespace PriceUpdater.Controllers
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
            return View(db.ACEModules.ToList());
        }

        public ActionResult Payments()
        {
            return View(db.Payments.ToList());
        }

        public ActionResult ModuleOrders()
        {
            return View(db.ModuleOrders.ToList());
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
                db.ACEModules.Add(acemodule);
                db.SaveChanges();
                return RedirectToAction("Modules");
            }

            return View(acemodule);
        }

        //
        // GET: /Admin/Create

        public ActionResult CreatePayment()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreatePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Payments");
            }

            return View(payment);
        }

        //
        // GET: /Admin/Create

        public ActionResult CreateModuleOrder()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreateModuleOrder(ModuleOrder order)
        {
            if (ModelState.IsValid)
            {
                db.ModuleOrders.Add(order);
                db.SaveChanges();
                return RedirectToAction("ModuleOrders");
            }

            return View(order);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditModule(int id = 0)
        {
            ACEModule acemodule = db.ACEModules.Find(id);
            if (acemodule == null)
            {
                return HttpNotFound();
            }
            return View(acemodule);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditModule(ACEModule acemodule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acemodule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acemodule);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditPayment(int id = 0)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Payments");
            }
            return View(payment);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditModuleOrder(int id = 0)
        {
            ModuleOrder order = db.ModuleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditModuleOrder(ModuleOrder order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ModuleOrders");
            }
            return View(order);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult DeleteModule(int id = 0)
        {
            ACEModule acemodule = db.ACEModules.Find(id);
            if (acemodule == null)
            {
                return HttpNotFound();
            }
            return View(acemodule);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeleteModule")]
        public ActionResult DeleteModuleConfirmed(int id)
        {
            ACEModule acemodule = db.ACEModules.Find(id);
            db.ACEModules.Remove(acemodule);
            db.SaveChanges();
            return RedirectToAction("Modules");
        }

        public ActionResult DeletePayment(int id = 0)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeletePayment")]
        public ActionResult DeletePaymentConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Payments");
        }

        public ActionResult DeleteModuleOrder(int id = 0)
        {
            ModuleOrder order = db.ModuleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("DeleteModuleOrder")]
        public ActionResult DeleteModuleOrderConfirmed(int id)
        {
            ModuleOrder order = db.ModuleOrders.Find(id);
            db.ModuleOrders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("ModuleOrders");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}