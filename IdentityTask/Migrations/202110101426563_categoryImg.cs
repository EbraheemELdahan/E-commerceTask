namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CatName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CatName");
        }
    }
}
