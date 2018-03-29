namespace AssetManagement.Migrations.AssetManagementScripts
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityId = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(),
                        Landmark = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(maxLength: 5),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FacilityId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        Quantity = c.String(),
                        Description = c.String(),
                        Size = c.String(),
                        Color = c.String(),
                        FacilityId = c.Int(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId, cascadeDelete: true)
                .Index(t => t.FacilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "FacilityId", "dbo.Facilities");
            DropIndex("dbo.Resources", new[] { "FacilityId" });
            DropTable("dbo.Resources");
            DropTable("dbo.Facilities");
        }
    }
}
