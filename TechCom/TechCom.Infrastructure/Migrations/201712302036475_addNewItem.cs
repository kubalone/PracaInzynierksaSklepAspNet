namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "PriceDelivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetail", "TypeOfDelivery", c => c.String());
            DropColumn("dbo.Order", "WorthOfDelivery");
            DropColumn("dbo.Order", "PriceDelivery");
            DropColumn("dbo.Order", "TypeOfDelivery");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "TypeOfDelivery", c => c.String());
            AddColumn("dbo.Order", "PriceDelivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "WorthOfDelivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderDetail", "TypeOfDelivery");
            DropColumn("dbo.OrderDetail", "PriceDelivery");
        }
    }
}
