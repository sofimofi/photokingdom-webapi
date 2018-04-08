namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addplaceidtoping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pings", "AttractionGooglePlaceId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pings", "AttractionGooglePlaceId");
        }
    }
}
