namespace HomeSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HomeSite.Models;
    using System.Collections.Generic;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeSite.Models.HomeSiteDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HomeSite.Models.HomeSiteDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Cows.AddOrUpdate(c => c.tagNumber,
                new Cow { Id = 1, tagNumber = 12, Name = "Charlotte", Description = "Gray", DOB = DateTime.Parse("1/1/2006"), Sex="F", Owner="QOO", Status="F" }
                );

            context.Bulls.AddOrUpdate(b => b.Name,
                new Bull { Id = 1, Name="Bully", Description="Black", PurchasedFrom="South of Anadarko", Status="D" },
                new Bull { Id = 2, Name="DW", Description="Black", PurchasedFrom="Burtschi Road", Status="D" },
                new Bull { Id = 3, Name="Killer Storm", Description = "Black", PurchasedFrom="KS", Status = "F" }
                );

            SeedMembership();
        }

        private void SeedMembership()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("mhowell", false) == null)
            {
                membership.CreateUserAndAccount("mhowell", "password");
            }
            if (!roles.GetRolesForUser("mhowell").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "mhowell" }, new[] { "admin" });
            }
        }
    }
}
