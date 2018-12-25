namespace HomeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bulls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PurchasedFrom = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tagNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Sex = c.String(),
                        Owner = c.String(),
                        Status = c.String(),
                        Notes = c.String(),
                        Dam = c.Int(nullable: false),
                        Sire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FavoriteRestaurant = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
            DropTable("dbo.Cows");
            DropTable("dbo.Bulls");
        }
    }
}
