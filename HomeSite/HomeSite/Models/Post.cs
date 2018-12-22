using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime postDate { get; set; }
        public string Content { get; set; }
        public DateTime editDate { get; set; }
    }
}