namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class structure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer = c.String(),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        ProductWithDiscount = c.Boolean(nullable: false),
                        ImageProduct = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ShippingID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.OrderDetail", t => t.ShippingID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ShippingID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Street = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        Comments = c.String(),
                        DateOfTheOrder = c.DateTime(nullable: false),
                        ValueOfOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShippingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "ShippingID", "dbo.OrderDetail");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Order", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "ShippingID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
