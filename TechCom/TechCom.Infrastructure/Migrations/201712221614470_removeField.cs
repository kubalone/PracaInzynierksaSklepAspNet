namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetail", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "Country", c => c.String());
        }
    }
}
