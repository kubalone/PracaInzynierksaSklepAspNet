namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "PriceDelivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "TypeOfDelivery", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "TypeOfDelivery");
            DropColumn("dbo.Order", "PriceDelivery");
        }
    }
}
