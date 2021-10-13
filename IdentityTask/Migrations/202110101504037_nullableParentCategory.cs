namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableParentCategory : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryID" });
            AlterColumn("dbo.Categories", "ParentCategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategoryID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "ParentCategoryID" });
            AlterColumn("dbo.Categories", "ParentCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ParentCategoryID");
        }
    }
}
