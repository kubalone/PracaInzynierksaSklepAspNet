namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "DeliveryOption_DeliveryOptionID", "dbo.DeliveryOption");
            DropIndex("dbo.Order", new[] { "DeliveryOption_DeliveryOptionID" });
            AddColumn("dbo.OrderDetail", "SelectedAnswer", c => c.String());
            DropColumn("dbo.Order", "DeliveryOption_DeliveryOptionID");
            DropColumn("dbo.OrderDetail", "DeliveryOptionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "DeliveryOptionID", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "DeliveryOption_DeliveryOptionID", c => c.Int());
            DropColumn("dbo.OrderDetail", "SelectedAnswer");
            CreateIndex("dbo.Order", "DeliveryOption_DeliveryOptionID");
            AddForeignKey("dbo.Order", "DeliveryOption_DeliveryOptionID", "dbo.DeliveryOption", "DeliveryOptionID");
        }
    }
}
