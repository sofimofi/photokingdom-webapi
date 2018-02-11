namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecascadecycles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents");
            DropForeignKey("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents");
            DropForeignKey("dbo.ContinentProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.CountryProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads");
            DropIndex("dbo.ContinentPhotowarPhotorequests", new[] { "RequestingResidentId" });
            DropIndex("dbo.ContinentProfiles", new[] { "PhotoId" });
            DropIndex("dbo.CountryPhotowarPhotorequests", new[] { "RecipientResidentId" });
            DropIndex("dbo.CountryProfiles", new[] { "PhotoId" });
            DropIndex("dbo.Queues", new[] { "AttractionPhotowarUploadId" });
            AlterColumn("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", c => c.Int());
            AlterColumn("dbo.ContinentProfiles", "PhotoId", c => c.Int());
            AlterColumn("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", c => c.Int());
            AlterColumn("dbo.CountryProfiles", "PhotoId", c => c.Int());
            AlterColumn("dbo.Queues", "AttractionPhotowarUploadId", c => c.Int());
            CreateIndex("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId");
            CreateIndex("dbo.ContinentProfiles", "PhotoId");
            CreateIndex("dbo.CountryPhotowarPhotorequests", "RecipientResidentId");
            CreateIndex("dbo.CountryProfiles", "PhotoId");
            CreateIndex("dbo.Queues", "AttractionPhotowarUploadId");
            AddForeignKey("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents", "Id");
            AddForeignKey("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents", "Id");
            AddForeignKey("dbo.ContinentProfiles", "PhotoId", "dbo.Photos", "Id");
            AddForeignKey("dbo.CountryProfiles", "PhotoId", "dbo.Photos", "Id");
            AddForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads");
            DropForeignKey("dbo.CountryProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.ContinentProfiles", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents");
            DropForeignKey("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents");
            DropIndex("dbo.Queues", new[] { "AttractionPhotowarUploadId" });
            DropIndex("dbo.CountryProfiles", new[] { "PhotoId" });
            DropIndex("dbo.CountryPhotowarPhotorequests", new[] { "RecipientResidentId" });
            DropIndex("dbo.ContinentProfiles", new[] { "PhotoId" });
            DropIndex("dbo.ContinentPhotowarPhotorequests", new[] { "RequestingResidentId" });
            AlterColumn("dbo.Queues", "AttractionPhotowarUploadId", c => c.Int(nullable: false));
            AlterColumn("dbo.CountryProfiles", "PhotoId", c => c.Int(nullable: false));
            AlterColumn("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContinentProfiles", "PhotoId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Queues", "AttractionPhotowarUploadId");
            CreateIndex("dbo.CountryProfiles", "PhotoId");
            CreateIndex("dbo.CountryPhotowarPhotorequests", "RecipientResidentId");
            CreateIndex("dbo.ContinentProfiles", "PhotoId");
            CreateIndex("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId");
            AddForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CountryProfiles", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContinentProfiles", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContinentPhotowarPhotorequests", "RequestingResidentId", "dbo.Residents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CountryPhotowarPhotorequests", "RecipientResidentId", "dbo.Residents", "Id", cascadeDelete: true);
        }
    }
}
