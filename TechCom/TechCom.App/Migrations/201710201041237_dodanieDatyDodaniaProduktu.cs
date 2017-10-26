namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanieDatyDodaniaProduktu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "DateAdded");
        }
    }
}
