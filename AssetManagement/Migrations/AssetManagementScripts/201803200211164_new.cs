namespace AssetManagement.Migrations.AssetManagementScripts
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facilities", "FacilityName", c => c.String(nullable: false));
            AlterColumn("dbo.Facilities", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Facilities", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Facilities", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Resources", "ResourceName", c => c.String(nullable: false));
            AlterColumn("dbo.Resources", "Quantity", c => c.String(nullable: false));
            AlterColumn("dbo.Resources", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Facilities", "UpdatedBy");
            DropColumn("dbo.Resources", "UpdatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "UpdatedBy", c => c.String());
            AddColumn("dbo.Facilities", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Resources", "Description", c => c.String());
            AlterColumn("dbo.Resources", "Quantity", c => c.String());
            AlterColumn("dbo.Resources", "ResourceName", c => c.String());
            AlterColumn("dbo.Facilities", "State", c => c.String());
            AlterColumn("dbo.Facilities", "City", c => c.String());
            AlterColumn("dbo.Facilities", "Address", c => c.String());
            AlterColumn("dbo.Facilities", "FacilityName", c => c.String());
        }
    }
}
