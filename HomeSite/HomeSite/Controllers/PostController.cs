using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;

namespace HomeSite.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var model =
                from p in _posts
                orderby p.postDate descending
                select p;

            return View(model);
        }

        public ActionResult LatestPost()
        {
            var latestRevew = from p in _posts
                              orderby p.postDate descending
                              select p;

            return PartialView("_Post", latestRevew.First());
        }

        static List<Post> _posts = new List<Post>
        {
            new Post
            {
                Id = 1,
                Title = "First Post",
                postDate = DateTime.Now,
                Content = "This is the first post."
            }
        };
    }
}