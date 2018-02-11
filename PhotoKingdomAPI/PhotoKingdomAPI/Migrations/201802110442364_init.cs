namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttractionPhotowars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AttractionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attractions", t => t.AttractionId, cascadeDelete: true)
                .Index(t => t.AttractionId);
            
            CreateTable(
                "dbo.Attractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        IsActive = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        CountryId = c.Int(nullable: false),
                        ProvinceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .Index(t => t.ContinentId);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResidentContinentOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOfOwn = c.DateTime(nullable: false),
                        EndOfOwn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ResidentId = c.Int(nullable: false),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.ContinentId);
            
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false, maxLength: 1),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Int(nullable: false),
                        AvatarImagePath = c.String(maxLength: 100),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: false)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.AttractionPhotowarUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsWinner = c.Int(),
                        IsLoser = c.Int(),
                        PhotoId = c.Int(nullable: false),
                        AttractionPhotowarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AttractionPhotowars", t => t.AttractionPhotowarId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.AttractionPhotowarId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoFilePath = c.String(nullable: false, maxLength: 100),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        ResidentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId);
            
            CreateTable(
                "dbo.ContinentPhotowarRequestedphotoUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsChosenCompetitor = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                        ContinentPhotowarPhotorequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContinentPhotowarPhotorequests", t => t.ContinentPhotowarPhotorequestId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.ContinentPhotowarPhotorequestId);
            
            CreateTable(
                "dbo.ContinentPhotowarPhotorequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        AcceptanceDate = c.DateTime(),
                        DenialDate = c.DateTime(),
                        ContinentPhotowarId = c.Int(nullable: false),
                        RequestingResidentId = c.Int(),
                        RecipientResidentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContinentPhotowars", t => t.ContinentPhotowarId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.RecipientResidentId, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.RequestingResidentId, cascadeDelete: false)
                .Index(t => t.ContinentPhotowarId)
                .Index(t => t.RequestingResidentId)
                .Index(t => t.RecipientResidentId);
            
            CreateTable(
                "dbo.ContinentPhotowars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeclarationDate = c.DateTime(nullable: false),
                        AcceptanceDate = c.DateTime(),
                        SurrenderDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsCancelled = c.Int(nullable: false),
                        DeclaringContinentId = c.Int(nullable: false),
                        RecipentContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContinentProfiles", t => t.DeclaringContinentId, cascadeDelete: true)
                .ForeignKey("dbo.ContinentProfiles", t => t.RecipentContinentId, cascadeDelete: false)
                .Index(t => t.DeclaringContinentId)
                .Index(t => t.RecipentContinentId);
            
            CreateTable(
                "dbo.ContinentPhotowarUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsWinner = c.Int(),
                        IsLoser = c.Int(),
                        PhotoId = c.Int(nullable: false),
                        ContinentPhotowarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContinentPhotowars", t => t.ContinentPhotowarId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.ContinentPhotowarId);
            
            CreateTable(
                "dbo.ContinentProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContinentId = c.Int(nullable: false),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: false)
                .Index(t => t.ContinentId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.CountryPhotowarRequestedphotoUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsChosenCompetitor = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                        CountryPhotowarPhotorequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryPhotowarPhotorequests", t => t.CountryPhotowarPhotorequestId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.CountryPhotowarPhotorequestId);
            
            CreateTable(
                "dbo.CountryPhotowarPhotorequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        AcceptanceDate = c.DateTime(),
                        DenialDate = c.DateTime(),
                        CountryPhotowarId = c.Int(nullable: false),
                        RequestingResidentId = c.Int(),
                        RecipientResidentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryPhotowars", t => t.CountryPhotowarId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.RecipientResidentId, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.RequestingResidentId, cascadeDelete: false)
                .Index(t => t.CountryPhotowarId)
                .Index(t => t.RequestingResidentId)
                .Index(t => t.RecipientResidentId);
            
            CreateTable(
                "dbo.CountryPhotowars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeclarationDate = c.DateTime(nullable: false),
                        AcceptanceDate = c.DateTime(),
                        SurrenderDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsCancelled = c.Int(nullable: false),
                        DeclaringCountryId = c.Int(nullable: false),
                        RecipentCountryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryProfiles", t => t.DeclaringCountryId, cascadeDelete: true)
                .ForeignKey("dbo.CountryProfiles", t => t.RecipentCountryId, cascadeDelete: false)
                .Index(t => t.DeclaringCountryId)
                .Index(t => t.RecipentCountryId);
            
            CreateTable(
                "dbo.CountryPhotowarUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsWinner = c.Int(),
                        IsLoser = c.Int(),
                        PhotoId = c.Int(nullable: false),
                        CountryPhotowarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryPhotowars", t => t.CountryPhotowarId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.CountryPhotowarId);
            
            CreateTable(
                "dbo.CountryProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: false)
                .Index(t => t.CountryId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Pings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PingDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        ResidentId = c.Int(nullable: false),
                        AttractionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attractions", t => t.AttractionId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.AttractionId);
            
            CreateTable(
                "dbo.ResidentAttractionOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOfOwn = c.DateTime(nullable: false),
                        EndOfOwn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ResidentId = c.Int(nullable: false),
                        AttractionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attractions", t => t.AttractionId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.AttractionId);
            
            CreateTable(
                "dbo.ResidentCityOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOfOwn = c.DateTime(nullable: false),
                        EndOfOwn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ResidentId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.ResidentCountryOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOfOwn = c.DateTime(nullable: false),
                        EndOfOwn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ResidentId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.ResidentProvinceOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOfOwn = c.DateTime(nullable: false),
                        EndOfOwn = c.DateTime(),
                        Title = c.String(nullable: false, maxLength: 50),
                        ResidentId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: true)
                .Index(t => t.ResidentId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QueueDate = c.DateTime(nullable: false),
                        AttractionId = c.Int(nullable: false),
                        AttractionPhotowarUploadId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attractions", t => t.AttractionId, cascadeDelete: true)
                .ForeignKey("dbo.AttractionPhotowarUploads", t => t.AttractionPhotowarUploadId, cascadeDelete: false)
                .Index(t => t.AttractionId)
                .Index(t => t.AttractionPhotowarUploadId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContinentPhotowarUploadResidents",
                c => new
                    {
                        ContinentPhotowarUpload_Id = c.Int(),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ContinentPhotowarUpload_Id, t.Resident_Id })
                .ForeignKey("dbo.ContinentPhotowarUploads", t => t.ContinentPhotowarUpload_Id, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.Resident_Id, cascadeDelete: false)
                .Index(t => t.ContinentPhotowarUpload_Id)
                .Index(t => t.Resident_Id);
            
            CreateTable(
                "dbo.CountryPhotowarUploadResidents",
                c => new
                    {
                        CountryPhotowarUpload_Id = c.Int(),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.CountryPhotowarUpload_Id, t.Resident_Id })
                .ForeignKey("dbo.CountryPhotowarUploads", t => t.CountryPhotowarUpload_Id, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.Resident_Id, cascadeDelete: false)
                .Index(t => t.CountryPhotowarUpload_Id)
                .Index(t => t.Resident_Id);
            
            CreateTable(
                "dbo.AttractionPhotowarUploadResidents",
                c => new
                    {
                        AttractionPhotowarUpload_Id = c.Int(),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.AttractionPhotowarUpload_Id, t.Resident_Id })
                .ForeignKey("dbo.AttractionPhotowarUploads", t => t.AttractionPhotowarUpload_Id, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.Resident_Id, cascadeDelete: false)
                .Index(t => t.AttractionPhotowarUpload_Id)
                .Index(t => t.Resident_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads");
            DropForeignKey("dbo.Queues", "AttractionId", "dbo.Attractions");
            DropForeignKey("dbo.Attractions", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.ResidentProvinceOwns", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.ResidentProvinceOwns", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Provinces", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ResidentCountryOwns", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.ResidentCountryOwns", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ResidentContinentOwns", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.ResidentCityOwns", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.ResidentCityOwns", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ResidentAttractionOwns", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.ResidentAttractionOwns", "AttractionId", "dbo.Attractions");
            DropForeignKey("dbo.CountryPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents");
            DropForeignKey("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents");
            DropForeignKey("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents");
            DropForeignKey("dbo.ContinentPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents");
            DropForeignKey("dbo.Pings", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.Pings", "AttractionId", "dbo.Attractions");
            DropForeignKey("dbo.Residents", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AttractionPhotowarUploadResidents", "Resident_Id", "dbo.Residents");
            DropForeignKey("dbo.AttractionPhotowarUploadResidents", "AttractionPhotowarUpload_Id", "dbo.AttractionPhotowarUploads");
            DropForeignKey("dbo.Photos", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.CountryPhotowarRequestedphotoUploads", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CountryPhotowarRequestedphotoUploads", "CountryPhotowarPhotorequestId", "dbo.CountryPhotowarPhotorequests");
            DropForeignKey("dbo.CountryPhotowarPhotorequests", "CountryPhotowarId", "dbo.CountryPhotowars");
            DropForeignKey("dbo.CountryPhotowars", "RecipentCountryId", "dbo.CountryProfiles");
            DropForeignKey("dbo.CountryPhotowars", "DeclaringCountryId", "dbo.CountryProfiles");
            DropForeignKey("dbo.CountryProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CountryProfiles", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CountryPhotowarUploadResidents", "Resident_Id", "dbo.Residents");
            DropForeignKey("dbo.CountryPhotowarUploadResidents", "CountryPhotowarUpload_Id", "dbo.CountryPhotowarUploads");
            DropForeignKey("dbo.CountryPhotowarUploads", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CountryPhotowarUploads", "CountryPhotowarId", "dbo.CountryPhotowars");
            DropForeignKey("dbo.ContinentPhotowarRequestedphotoUploads", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.ContinentPhotowarRequestedphotoUploads", "ContinentPhotowarPhotorequestId", "dbo.ContinentPhotowarPhotorequests");
            DropForeignKey("dbo.ContinentPhotowarPhotorequests", "ContinentPhotowarId", "dbo.ContinentPhotowars");
            DropForeignKey("dbo.ContinentPhotowars", "RecipentContinentId", "dbo.ContinentProfiles");
            DropForeignKey("dbo.ContinentPhotowars", "DeclaringContinentId", "dbo.ContinentProfiles");
            DropForeignKey("dbo.ContinentProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.ContinentProfiles", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.ContinentPhotowarUploadResidents", "Resident_Id", "dbo.Residents");
            DropForeignKey("dbo.ContinentPhotowarUploadResidents", "ContinentPhotowarUpload_Id", "dbo.ContinentPhotowarUploads");
            DropForeignKey("dbo.ContinentPhotowarUploads", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.ContinentPhotowarUploads", "ContinentPhotowarId", "dbo.ContinentPhotowars");
            DropForeignKey("dbo.AttractionPhotowarUploads", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.AttractionPhotowarUploads", "AttractionPhotowarId", "dbo.AttractionPhotowars");
            DropForeignKey("dbo.ResidentContinentOwns", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.AttractionPhotowars", "AttractionId", "dbo.Attractions");
            DropIndex("dbo.AttractionPhotowarUploadResidents", new[] { "Resident_Id" });
            DropIndex("dbo.AttractionPhotowarUploadResidents", new[] { "AttractionPhotowarUpload_Id" });
            DropIndex("dbo.CountryPhotowarUploadResidents", new[] { "Resident_Id" });
            DropIndex("dbo.CountryPhotowarUploadResidents", new[] { "CountryPhotowarUpload_Id" });
            DropIndex("dbo.ContinentPhotowarUploadResidents", new[] { "Resident_Id" });
            DropIndex("dbo.ContinentPhotowarUploadResidents", new[] { "ContinentPhotowarUpload_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Queues", new[] { "AttractionPhotowarUploadId" });
            DropIndex("dbo.Queues", new[] { "AttractionId" });
            DropIndex("dbo.Provinces", new[] { "CountryId" });
            DropIndex("dbo.ResidentProvinceOwns", new[] { "ProvinceId" });
            DropIndex("dbo.ResidentProvinceOwns", new[] { "ResidentId" });
            DropIndex("dbo.ResidentCountryOwns", new[] { "CountryId" });
            DropIndex("dbo.ResidentCountryOwns", new[] { "ResidentId" });
            DropIndex("dbo.ResidentCityOwns", new[] { "CityId" });
            DropIndex("dbo.ResidentCityOwns", new[] { "ResidentId" });
            DropIndex("dbo.ResidentAttractionOwns", new[] { "AttractionId" });
            DropIndex("dbo.ResidentAttractionOwns", new[] { "ResidentId" });
            DropIndex("dbo.Pings", new[] { "AttractionId" });
            DropIndex("dbo.Pings", new[] { "ResidentId" });
            DropIndex("dbo.CountryProfiles", new[] { "PhotoId" });
            DropIndex("dbo.CountryProfiles", new[] { "CountryId" });
            DropIndex("dbo.CountryPhotowarUploads", new[] { "CountryPhotowarId" });
            DropIndex("dbo.CountryPhotowarUploads", new[] { "PhotoId" });
            DropIndex("dbo.CountryPhotowars", new[] { "RecipentCountryId" });
            DropIndex("dbo.CountryPhotowars", new[] { "DeclaringCountryId" });
            DropIndex("dbo.CountryPhotowarPhotorequests", new[] { "RecipientResidentId" });
            DropIndex("dbo.CountryPhotowarPhotorequests", new[] { "RequestingResidentId" });
            DropIndex("dbo.CountryPhotowarPhotorequests", new[] { "CountryPhotowarId" });
            DropIndex("dbo.CountryPhotowarRequestedphotoUploads", new[] { "CountryPhotowarPhotorequestId" });
            DropIndex("dbo.CountryPhotowarRequestedphotoUploads", new[] { "PhotoId" });
            DropIndex("dbo.ContinentProfiles", new[] { "PhotoId" });
            DropIndex("dbo.ContinentProfiles", new[] { "ContinentId" });
            DropIndex("dbo.ContinentPhotowarUploads", new[] { "ContinentPhotowarId" });
            DropIndex("dbo.ContinentPhotowarUploads", new[] { "PhotoId" });
            DropIndex("dbo.ContinentPhotowars", new[] { "RecipentContinentId" });
            DropIndex("dbo.ContinentPhotowars", new[] { "DeclaringContinentId" });
            DropIndex("dbo.ContinentPhotowarPhotorequests", new[] { "RecipientResidentId" });
            DropIndex("dbo.ContinentPhotowarPhotorequests", new[] { "RequestingResidentId" });
            DropIndex("dbo.ContinentPhotowarPhotorequests", new[] { "ContinentPhotowarId" });
            DropIndex("dbo.ContinentPhotowarRequestedphotoUploads", new[] { "ContinentPhotowarPhotorequestId" });
            DropIndex("dbo.ContinentPhotowarRequestedphotoUploads", new[] { "PhotoId" });
            DropIndex("dbo.Photos", new[] { "ResidentId" });
            DropIndex("dbo.AttractionPhotowarUploads", new[] { "AttractionPhotowarId" });
            DropIndex("dbo.AttractionPhotowarUploads", new[] { "PhotoId" });
            DropIndex("dbo.Residents", new[] { "CityId" });
            DropIndex("dbo.ResidentContinentOwns", new[] { "ContinentId" });
            DropIndex("dbo.ResidentContinentOwns", new[] { "ResidentId" });
            DropIndex("dbo.Countries", new[] { "ContinentId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Attractions", new[] { "CityId" });
            DropIndex("dbo.AttractionPhotowars", new[] { "AttractionId" });
            DropTable("dbo.AttractionPhotowarUploadResidents");
            DropTable("dbo.CountryPhotowarUploadResidents");
            DropTable("dbo.ContinentPhotowarUploadResidents");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Queues");
            DropTable("dbo.Provinces");
            DropTable("dbo.ResidentProvinceOwns");
            DropTable("dbo.ResidentCountryOwns");
            DropTable("dbo.ResidentCityOwns");
            DropTable("dbo.ResidentAttractionOwns");
            DropTable("dbo.Pings");
            DropTable("dbo.CountryProfiles");
            DropTable("dbo.CountryPhotowarUploads");
            DropTable("dbo.CountryPhotowars");
            DropTable("dbo.CountryPhotowarPhotorequests");
            DropTable("dbo.CountryPhotowarRequestedphotoUploads");
            DropTable("dbo.ContinentProfiles");
            DropTable("dbo.ContinentPhotowarUploads");
            DropTable("dbo.ContinentPhotowars");
            DropTable("dbo.ContinentPhotowarPhotorequests");
            DropTable("dbo.ContinentPhotowarRequestedphotoUploads");
            DropTable("dbo.Photos");
            DropTable("dbo.AttractionPhotowarUploads");
            DropTable("dbo.Residents");
            DropTable("dbo.ResidentContinentOwns");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Attractions");
            DropTable("dbo.AttractionPhotowars");
        }
    }
}
