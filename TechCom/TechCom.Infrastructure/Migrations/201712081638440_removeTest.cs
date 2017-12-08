namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Remove", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Remove");
        }
    }
}
