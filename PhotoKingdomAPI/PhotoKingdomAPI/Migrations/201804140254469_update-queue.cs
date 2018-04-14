namespace PhotoKingdomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatequeue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads");
            DropIndex("dbo.Queues", new[] { "AttractionPhotowarUploadId" });
            AddColumn("dbo.Queues", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Queues", "PhotoId");
            AddForeignKey("dbo.Queues", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
            DropColumn("dbo.Queues", "AttractionPhotowarUploadId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queues", "AttractionPhotowarUploadId", c => c.Int());
            DropForeignKey("dbo.Queues", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Queues", new[] { "PhotoId" });
            DropColumn("dbo.Queues", "PhotoId");
            CreateIndex("dbo.Queues", "AttractionPhotowarUploadId");
            AddForeignKey("dbo.Queues", "AttractionPhotowarUploadId", "dbo.AttractionPhotowarUploads", "Id");
        }
    }
}
