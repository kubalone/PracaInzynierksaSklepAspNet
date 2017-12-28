namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Product", "Manufacturer", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String());
            AlterColumn("dbo.Product", "Manufacturer", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
        }
    }
}
