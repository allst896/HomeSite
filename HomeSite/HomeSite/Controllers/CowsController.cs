using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;
using PagedList;

namespace HomeSite.Controllers
{
    public class CowsController : Controller
    {
        private HomeSiteDb db = new HomeSiteDb();
        private IHomeSiteDb _db;

        public CowsController()
        {
            _db = new HomeSiteDb();
        }

        public CowsController(IHomeSiteDb idb)
        {
            _db = idb;
        }

        // GET: Cows
        public ActionResult Index()
        {
            return View(db.Cows.ToList());
        }

        //GET: Cows/Calves/5
        public ActionResult Calves(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cow cow = db.Cows.Find(id);
            if (cow == null)
            {
                return HttpNotFound();
            }
            string cowname = cow.Name;
            List<CalfListViewModel> listCalves = new List<CalfListViewModel>();

            listCalves =
                _db.Query<Cow>()
                .Where(r => r.Dam == cow.tagNumber)
                .OrderByDescending(r => r.DOB)
                .Select(r => new CalfListViewModel
                {
                    Id = r.Id,
                    ParentName = cowname,
                    ParentSex = "F",
                    Name = r.Name,
                    DOB = r.DOB,
                    tagNumber = r.tagNumber,
                    Sex = r.Sex,
                    Status = r.Status,
                    Owner = r.Owner,
                    Sire = r.Sire
                }).ToList();

            var model = listCalves.ToPagedList(page, 10);

            return View(model);
        }

        // GET: Cows/Details/5
        public ActionResult Details(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cow cow = db.Cows.Find(id);
            if (cow == null)
            {
                return HttpNotFound();
            }
            return View(cow);
        }

        // GET: Cows/Create

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tagNumber,Name,Description,DOB,Sex,Owner,Status,Notes,Dam,Sire")] Cow cow)
        {
            if (ModelState.IsValid)
            {
                db.Cows.Add(cow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cow);
        }

        // GET: Cows/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cow cow = db.Cows.Find(id);
            if (cow == null)
            {
                return HttpNotFound();
            }
            return View(cow);
        }

        // POST: Cows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tagNumber,Name,Description,DOB,Sex,Owner,Status,Notes,Dam,Sire")] Cow cow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cow);
        }

        // GET: Cows/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cow cow = db.Cows.Find(id);
            if (cow == null)
            {
                return HttpNotFound();
            }
            return View(cow);
        }

        // POST: Cows/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cow cow = db.Cows.Find(id);
            db.Cows.Remove(cow);
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
