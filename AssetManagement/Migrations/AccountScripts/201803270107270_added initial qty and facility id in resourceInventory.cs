namespace AssetManagement.Migrations.AccountScripts
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinitialqtyandfacilityidinresourceInventory : DbMigration
    {
        public override void Up()
        {            
            AddColumn("dbo.ResourceInventories", "OriginalQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.ResourceInventories", "FacilityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceInventories", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.ResourceCheckViewModels", "ResourceCheckList_FacilityId", "dbo.ResourceCheckLists");
            DropIndex("dbo.ResourceInventories", new[] { "FacilityId" });
            DropIndex("dbo.ResourceCheckViewModels", new[] { "ResourceCheckList_FacilityId" });
            DropColumn("dbo.ResourceInventories", "FacilityId");
            DropColumn("dbo.ResourceInventories", "OriginalQuantity");
            DropTable("dbo.ResourceCheckViewModels");
            DropTable("dbo.ResourceCheckLists");
        }
    }
}
