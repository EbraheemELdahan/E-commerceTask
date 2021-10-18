namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shippeddata1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shipped_Data", "BuildingNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shipped_Data", "BuildingNumber", c => c.Int(nullable: false));
        }
    }
}
