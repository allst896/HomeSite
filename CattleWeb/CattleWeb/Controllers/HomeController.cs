using CattleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CattleWeb.Controllers
{
    public class HomeController : Controller
    {
        CattleDb _db = new CattleDb();
        
        public ActionResult Index()
        {
            var model = _db.Cows.ToList();
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Cows", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}