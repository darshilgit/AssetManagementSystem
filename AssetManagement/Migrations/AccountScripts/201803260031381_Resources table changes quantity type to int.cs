namespace AssetManagement.Migrations.AccountScripts
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resourcestablechangesquantitytypetoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resources", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "Quantity", c => c.String(nullable: false));
        }
    }
}
