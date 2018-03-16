namespace AwkwardPresentationBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_name_from_presentationModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PresentationModels", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PresentationModels", "Name", c => c.Int(nullable: false));
        }
    }
}
