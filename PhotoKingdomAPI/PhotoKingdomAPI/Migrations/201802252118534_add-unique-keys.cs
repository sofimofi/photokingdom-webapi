namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduniquekeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Attractions", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.ContinentProfiles", new[] { "ContinentId" });
            DropIndex("dbo.Provinces", new[] { "CountryId" });
            DropIndex("dbo.CountryProfiles", new[] { "CountryId" });
            CreateIndex("dbo.Attractions", new[] { "Name", "CityId" }, unique: true);
            CreateIndex("dbo.Attractions", new[] { "Lat", "Lng" }, unique: true);
            CreateIndex("dbo.Cities", new[] { "Name", "ProvinceId" }, unique: true);
            CreateIndex("dbo.Residents", "UserName", unique: true);
            CreateIndex("dbo.Residents", "Email", unique: true);
            CreateIndex("dbo.ContinentProfiles", "ContinentId", unique: true);
            CreateIndex("dbo.Continents", "Name", unique: true);
            CreateIndex("dbo.Countries", "Name", unique: true);
            CreateIndex("dbo.Provinces", new[] { "Name", "CountryId" }, unique: true);
            CreateIndex("dbo.CountryProfiles", "CountryId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CountryProfiles", new[] { "CountryId" });
            DropIndex("dbo.Provinces", new[] { "Name", "CountryId" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Continents", new[] { "Name" });
            DropIndex("dbo.ContinentProfiles", new[] { "ContinentId" });
            DropIndex("dbo.Residents", new[] { "Email" });
            DropIndex("dbo.Residents", new[] { "UserName" });
            DropIndex("dbo.Cities", new[] { "Name", "ProvinceId" });
            DropIndex("dbo.Attractions", new[] { "Lat", "Lng" });
            DropIndex("dbo.Attractions", new[] { "Name", "CityId" });
            CreateIndex("dbo.CountryProfiles", "CountryId");
            CreateIndex("dbo.Provinces", "CountryId");
            CreateIndex("dbo.ContinentProfiles", "ContinentId");
            CreateIndex("dbo.Cities", "ProvinceId");
            CreateIndex("dbo.Attractions", "CityId");
        }
    }
}
