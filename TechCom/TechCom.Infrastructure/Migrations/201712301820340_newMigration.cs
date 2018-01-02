namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", c => c.Int());
            CreateIndex("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID");
            AddForeignKey("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", "dbo.DeliveryOption", "DeliveryOptionID");
            DropColumn("dbo.OrderDetail", "SelectedDeliveryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "SelectedDeliveryId", c => c.Int());
            DropForeignKey("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", "dbo.DeliveryOption");
            DropIndex("dbo.OrderDetail", new[] { "SelectedDelivery_DeliveryOptionID" });
            DropColumn("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID");
        }
    }
}
