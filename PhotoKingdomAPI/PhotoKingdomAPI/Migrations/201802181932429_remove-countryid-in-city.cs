namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecountryidincity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            AlterColumn("dbo.Cities", "ProvinceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Cities", "ProvinceId");
            AddForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: true);
            DropColumn("dbo.Cities", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cities", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Cities", "ProvinceId");
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
