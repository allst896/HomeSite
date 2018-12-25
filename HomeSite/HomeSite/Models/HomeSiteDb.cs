using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeSite.Models
{
    public class HomeSiteDb : DbContext
    {
        public HomeSiteDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Cow> Cows { get; set; }
        public DbSet<Bull> Bulls { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}