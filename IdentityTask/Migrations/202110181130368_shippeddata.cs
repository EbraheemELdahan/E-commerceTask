namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shippeddata : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Shipped_Data", "UserID");
            AddForeignKey("dbo.Shipped_Data", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipped_Data", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Shipped_Data", new[] { "UserID" });
        }
    }
}
