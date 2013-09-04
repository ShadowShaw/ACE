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
    public class UserController : Controller
    {
        private ACEContext db = new ACEContext();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.ModuleOrders.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            ModuleOrder moduleorder = db.ModuleOrders.Find(id);
            if (moduleorder == null)
            {
                return HttpNotFound();
            }
            return View(moduleorder);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(ModuleOrder moduleorder)
        {
            if (ModelState.IsValid)
            {
                db.ModuleOrders.Add(moduleorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moduleorder);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ModuleOrder moduleorder = db.ModuleOrders.Find(id);
            if (moduleorder == null)
            {
                return HttpNotFound();
            }
            return View(moduleorder);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(ModuleOrder moduleorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moduleorder);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ModuleOrder moduleorder = db.ModuleOrders.Find(id);
            if (moduleorder == null)
            {
                return HttpNotFound();
            }
            return View(moduleorder);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleOrder moduleorder = db.ModuleOrders.Find(id);
            db.ModuleOrders.Remove(moduleorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}