namespace AssetManagement.Migrations.AccountScripts
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResourcecInventorytableforresourcecheck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentQuantity = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 200),
                        ResourceId = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceInventories", "ResourceId", "dbo.Resources");
            DropIndex("dbo.ResourceInventories", new[] { "ResourceId" });
            DropTable("dbo.ResourceInventories");
        }
    }
}
