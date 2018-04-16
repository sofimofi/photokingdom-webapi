namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgpscoordinatestoping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pings", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Pings", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pings", "Lng");
            DropColumn("dbo.Pings", "Lat");
        }
    }
}
