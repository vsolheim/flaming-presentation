namespace AwkwardPresentationBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClickerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Data = c.String(),
                        Published_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PresentationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Title = c.String(),
                        Text = c.String(),
                        PresentationModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PresentationModels", t => t.PresentationModel_Id)
                .Index(t => t.PresentationModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "PresentationModel_Id", "dbo.PresentationModels");
            DropIndex("dbo.ImageModels", new[] { "PresentationModel_Id" });
            DropTable("dbo.ImageModels");
            DropTable("dbo.PresentationModels");
            DropTable("dbo.ClickerModels");
        }
    }
}
