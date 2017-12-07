namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ShortDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ShortDescription", c => c.String());
            DropColumn("dbo.Product", "Quantity");
        }
    }
}
