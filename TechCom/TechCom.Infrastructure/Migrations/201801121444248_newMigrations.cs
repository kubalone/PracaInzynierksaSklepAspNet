namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryOption",
                c => new
                    {
                        DeliveryOptionID = c.Int(nullable: false, identity: true),
                        TypeOfDelivery = c.String(nullable: false),
                        PriceOfDelivery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDetail_ShippingID = c.Int(),
                    })
                .PrimaryKey(t => t.DeliveryOptionID)
                .ForeignKey("dbo.OrderDetail", t => t.OrderDetail_ShippingID)
                .Index(t => t.OrderDetail_ShippingID);
            
            AddColumn("dbo.OrderDetail", "PriceDelivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetail", "TypeOfDelivery", c => c.String());
            AddColumn("dbo.OrderDetail", "SelectedDeliveryId", c => c.Int());
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Product", "Manufacturer", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            DropColumn("dbo.OrderDetail", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "Country", c => c.String());
            DropForeignKey("dbo.DeliveryOption", "OrderDetail_ShippingID", "dbo.OrderDetail");
            DropIndex("dbo.DeliveryOption", new[] { "OrderDetail_ShippingID" });
            AlterColumn("dbo.Product", "Description", c => c.String());
            AlterColumn("dbo.Product", "Manufacturer", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
            DropColumn("dbo.OrderDetail", "SelectedDeliveryId");
            DropColumn("dbo.OrderDetail", "TypeOfDelivery");
            DropColumn("dbo.OrderDetail", "PriceDelivery");
            DropTable("dbo.DeliveryOption");
        }
    }
}
