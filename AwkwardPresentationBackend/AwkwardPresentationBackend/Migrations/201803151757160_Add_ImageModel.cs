namespace AwkwardPresentationBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ImageModel : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
