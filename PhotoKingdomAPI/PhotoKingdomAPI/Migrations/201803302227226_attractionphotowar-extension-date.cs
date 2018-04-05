namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attractionphotowarextensiondate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttractionPhotowars", "ExtendedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttractionPhotowars", "ExtendedDate");
        }
    }
}
