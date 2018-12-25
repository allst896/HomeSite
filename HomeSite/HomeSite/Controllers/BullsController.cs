using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;

namespace HomeSite.Controllers
{
    public class BullsController : Controller
    {
        private HomeSiteDb db = new HomeSiteDb();

        // GET: Bulls
        public ActionResult Index()
        {
            return View(db.Bulls.ToList());
        }

        // GET: Bulls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bull bull = db.Bulls.Find(id);
            if (bull == null)
            {
                return HttpNotFound();
            }
            return View(bull);
        }

        // GET: Bulls/Create

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bulls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,PurchasedFrom")] Bull bull)
        {
            if (ModelState.IsValid)
            {
                db.Bulls.Add(bull);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bull);
        }

        // GET: Bulls/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bull bull = db.Bulls.Find(id);
            if (bull == null)
            {
                return HttpNotFound();
            }
            return View(bull);
        }

        // POST: Bulls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PurchasedFrom")] Bull bull)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bull).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bull);
        }

        // GET: Bulls/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bull bull = db.Bulls.Find(id);
            if (bull == null)
            {
                return HttpNotFound();
            }
            return View(bull);
        }

        // POST: Bulls/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bull bull = db.Bulls.Find(id);
            db.Bulls.Remove(bull);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
