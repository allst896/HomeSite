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
    public class BullsController : Controller
    {
        private HomeSiteDb db = new HomeSiteDb();
        private IHomeSiteDb _db;

        public BullsController()
        {
            _db = new HomeSiteDb();
        }

        public BullsController(IHomeSiteDb idb)
        {
            _db = idb;
        }

        // GET: Bulls
        public ActionResult Index()
        {
            return View(db.Bulls.ToList());
        }

        //GET: Bulls/Calves/5
        public ActionResult Calves(int? id, int page = 1)
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
            string bullname = bull.Name;
            List<CalfListViewModel> listCalves = new List<CalfListViewModel>();

            listCalves =
                _db.Query<Cow>()
                .Where(r => r.Sire == bull.Name)
                .OrderByDescending(r => r.DOB)
                .Select(r => new CalfListViewModel
                {
                    Id = r.Id,
                    ParentName = bullname,
                    ParentSex = "M",
                    Name = r.Name,
                    DOB = r.DOB,
                    tagNumber = r.tagNumber,
                    Sex = r.Sex,
                    Status = r.Status,
                    Owner = r.Owner,
                    Dam = r.Dam
                }).ToList();

            var model = listCalves.ToPagedList(page, 10);

            return View(model);
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
        public ActionResult Create([Bind(Include = "Id,Name,Description,PurchasedFrom,Status")] Bull bull)
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
        public ActionResult Edit([Bind(Include = "Id,Name,Description,PurchasedFrom,Status")] Bull bull)
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
