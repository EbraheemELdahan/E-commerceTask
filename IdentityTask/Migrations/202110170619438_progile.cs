namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class progile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserImg");
        }
    }
}
