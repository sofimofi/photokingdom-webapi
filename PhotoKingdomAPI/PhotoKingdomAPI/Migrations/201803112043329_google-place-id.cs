namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class googleplaceid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Attractions", new[] { "Lat", "Lng" });
            AddColumn("dbo.Attractions", "googlePlaceId", c => c.String(nullable: false));
            AlterColumn("dbo.Attractions", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Attractions", "Lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Photos", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Photos", "Lng", c => c.Double(nullable: false));
            CreateIndex("dbo.Attractions", new[] { "Lat", "Lng" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Attractions", new[] { "Lat", "Lng" });
            AlterColumn("dbo.Photos", "Lng", c => c.Single(nullable: false));
            AlterColumn("dbo.Photos", "Lat", c => c.Single(nullable: false));
            AlterColumn("dbo.Attractions", "Lng", c => c.Single(nullable: false));
            AlterColumn("dbo.Attractions", "Lat", c => c.Single(nullable: false));
            DropColumn("dbo.Attractions", "googlePlaceId");
            CreateIndex("dbo.Attractions", new[] { "Lat", "Lng" }, unique: true);
        }
    }
}
