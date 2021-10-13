namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "BrandID", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "BrandID" });
            RenameColumn(table: "dbo.Categories", name: "BrandID", newName: "Brand_ID");
            AlterColumn("dbo.Categories", "Brand_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Brand_ID");
            AddForeignKey("dbo.Categories", "Brand_ID", "dbo.Brands", "ID");
            DropColumn("dbo.Categories", "AdminID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "AdminID", c => c.String());
            DropForeignKey("dbo.Categories", "Brand_ID", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "Brand_ID" });
            AlterColumn("dbo.Categories", "Brand_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Categories", name: "Brand_ID", newName: "BrandID");
            CreateIndex("dbo.Categories", "BrandID");
            AddForeignKey("dbo.Categories", "BrandID", "dbo.Brands", "ID", cascadeDelete: true);
        }
    }
}
