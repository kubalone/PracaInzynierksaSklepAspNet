namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "SelectedDeliveryId", c => c.Int());
            DropColumn("dbo.OrderDetail", "SelectedAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "SelectedAnswer", c => c.String());
            DropColumn("dbo.OrderDetail", "SelectedDeliveryId");
        }
    }
}
