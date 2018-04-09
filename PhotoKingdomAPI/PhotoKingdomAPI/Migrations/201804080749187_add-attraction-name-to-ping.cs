namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattractionnametoping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pings", "AttractionId", "dbo.Attractions");
            DropIndex("dbo.Pings", new[] { "AttractionId" });
            RenameColumn(table: "dbo.Pings", name: "AttractionId", newName: "Attraction_Id");
            AddColumn("dbo.Pings", "AttractionName", c => c.String(nullable: false));
            AlterColumn("dbo.Pings", "Attraction_Id", c => c.Int());
            CreateIndex("dbo.Pings", "Attraction_Id");
            AddForeignKey("dbo.Pings", "Attraction_Id", "dbo.Attractions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pings", "Attraction_Id", "dbo.Attractions");
            DropIndex("dbo.Pings", new[] { "Attraction_Id" });
            AlterColumn("dbo.Pings", "Attraction_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Pings", "AttractionName");
            RenameColumn(table: "dbo.Pings", name: "Attraction_Id", newName: "AttractionId");
            CreateIndex("dbo.Pings", "AttractionId");
            AddForeignKey("dbo.Pings", "AttractionId", "dbo.Attractions", "Id", cascadeDelete: true);
        }
    }
}
