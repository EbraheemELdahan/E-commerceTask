namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barnd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "Brand_ID" });
            DropColumn("dbo.Categories", "Brand_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Brand_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Brand_ID");
            AddForeignKey("dbo.Categories", "Brand_ID", "dbo.Brands", "ID");
        }
    }
}
