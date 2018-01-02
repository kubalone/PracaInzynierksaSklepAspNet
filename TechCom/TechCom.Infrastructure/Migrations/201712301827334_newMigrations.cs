namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", "dbo.DeliveryOption");
            DropIndex("dbo.OrderDetail", new[] { "SelectedDelivery_DeliveryOptionID" });
            AddColumn("dbo.OrderDetail", "SelectedDeliveryId", c => c.Int());
            DropColumn("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", c => c.Int());
            DropColumn("dbo.OrderDetail", "SelectedDeliveryId");
            CreateIndex("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID");
            AddForeignKey("dbo.OrderDetail", "SelectedDelivery_DeliveryOptionID", "dbo.DeliveryOption", "DeliveryOptionID");
        }
    }
}
