using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CattleWeb.Models
{
    public class CattleDb : DbContext
    {
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Bull> Bulls { get; set; }
    }
}