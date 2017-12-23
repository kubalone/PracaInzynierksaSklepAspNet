namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetail", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.OrderDetail", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.OrderDetail", "Adress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.OrderDetail", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.OrderDetail", "ZipCode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.OrderDetail", "Phone", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetail", "Phone", c => c.String());
            AlterColumn("dbo.OrderDetail", "ZipCode", c => c.String());
            AlterColumn("dbo.OrderDetail", "City", c => c.String());
            AlterColumn("dbo.OrderDetail", "Adress", c => c.String());
            AlterColumn("dbo.OrderDetail", "Surname", c => c.String());
            AlterColumn("dbo.OrderDetail", "Name", c => c.String());
        }
    }
}
