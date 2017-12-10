namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Category_CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_CategoryID" });
            DropColumn("dbo.Product", "Category_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.Product", "Category_CategoryID");
            AddForeignKey("dbo.Product", "Category_CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
