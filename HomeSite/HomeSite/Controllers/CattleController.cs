using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;
using PagedList;

namespace HomeSite.Controllers
{
    public class CattleController : Controller
    {
        private IHomeSiteDb _db;

        public CattleController()
        {
            _db = new HomeSiteDb();
        }

        public CattleController(IHomeSiteDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Query<Cow>()
                   .Where(r => r.Name.StartsWith(term))
                   .Take(10)
                   .Select(r => new
                   {
                       label = r.Name
                   });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Cattle
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            List<CattleListViewModel> listBulls = new List<CattleListViewModel>();
            List<CattleListViewModel> listCows = new List<CattleListViewModel>();

            listBulls =
                _db.Query<Bull>()
                    .Where(r =>
                        (searchTerm == null || r.Name.Contains(searchTerm)) &&
                        (r.Status.Contains("Farm")))
                    .Select(r => new CattleListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        TagNumber = string.Empty,
                        Sex = "Male"
                    }).ToList();

            listCows =
                _db.Query<Cow>()
                    .OrderByDescending(r => r.tagNumber)
                    .Where(r => 
                        (searchTerm == null || r.tagNumber.ToString().Contains(searchTerm) || r.Name.Contains(searchTerm)) &&
                        (r.Status.Contains("Farm")))
                    .Select(r => new CattleListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        TagNumber = r.tagNumber.ToString(),
                        Sex = "Female"
                    }).ToList();

            var model = listBulls.Union(listCows).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Cattle", model);
            }

            return View(model);

            //return View();
        }

        public ActionResult Cows()
        {
            return View("Cows");
        }

        public ActionResult Bulls()
        {
            return View("Bulls");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}