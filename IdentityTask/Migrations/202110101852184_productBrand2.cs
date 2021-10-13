namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productBrand2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            RenameColumn(table: "dbo.Products", name: "Brand_ID", newName: "BrandID");
            RenameIndex(table: "dbo.Products", name: "IX_Brand_ID", newName: "IX_BrandID");
            AddColumn("dbo.Brands", "BrandImg", c => c.String());
            AlterColumn("dbo.Products", "CategoryID", c => c.Int());
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
            DropColumn("dbo.Products", "AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "AdminID", c => c.String());
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            DropColumn("dbo.Brands", "BrandImg");
            RenameIndex(table: "dbo.Products", name: "IX_BrandID", newName: "IX_Brand_ID");
            RenameColumn(table: "dbo.Products", name: "BrandID", newName: "Brand_ID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
