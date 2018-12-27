using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSite.Controllers
{
    public class CattleController : Controller
    {
        // GET: Cattle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cows()
        {
            return View("Cows");
        }

        public ActionResult Bulls()
        {
            return View("Bulls");
        }
    }
}