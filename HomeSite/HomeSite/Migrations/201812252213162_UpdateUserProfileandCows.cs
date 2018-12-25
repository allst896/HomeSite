namespace HomeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserProfileandCows : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfile", "FavoriteRestaurant");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "FavoriteRestaurant", c => c.String());
        }
    }
}
