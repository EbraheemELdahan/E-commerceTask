namespace IdentityTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repoteq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 150),
                        AdminID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        ParentCategoryID = c.Int(nullable: false),
                        AdminID = c.String(),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryID)
                .Index(t => t.ParentCategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 150),
                        ImageURL = c.String(),
                        Price = c.Single(nullable: false),
                        Rate = c.Int(),
                        IsPopular = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        AdminID = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ProductID })
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(),
                        TotalPrice = c.Single(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        Notes = c.String(maxLength: 150),
                        OrderDate = c.DateTime(nullable: false),
                        tax = c.Single(),
                        TotalPrice = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        shippedData = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Shipped_Data", t => t.shippedData)
                .Index(t => t.UserID)
                .Index(t => t.shippedData);
            
            CreateTable(
                "dbo.Shipped_Data",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        BuildingNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.SlidingImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaetOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "shippedData", "dbo.Shipped_Data");
            DropForeignKey("dbo.Orders", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favourites", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Favourites", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "BrandID", "dbo.Brands");
            DropIndex("dbo.Orders", new[] { "shippedData" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Favourites", new[] { "ProductID" });
            DropIndex("dbo.Favourites", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "BrandID" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryID" });
            DropColumn("dbo.AspNetUsers", "DaetOfBirth");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.SlidingImages");
            DropTable("dbo.Shipped_Data");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Favourites");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
