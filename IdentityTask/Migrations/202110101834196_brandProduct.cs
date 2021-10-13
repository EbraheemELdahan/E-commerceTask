namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brandProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brand_ID", c => c.Int());
            CreateIndex("dbo.Products", "Brand_ID");
            AddForeignKey("dbo.Products", "Brand_ID", "dbo.Brands", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_ID" });
            DropColumn("dbo.Products", "Brand_ID");
        }
    }
}
