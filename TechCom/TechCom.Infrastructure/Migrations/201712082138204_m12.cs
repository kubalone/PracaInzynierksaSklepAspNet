namespace TechCom.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            CreateTable(
                "dbo.Subcategory",
                c => new
                    {
                        SubcategoryID = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            AddColumn("dbo.Product", "SubcategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "SubcategoryID");
            AddForeignKey("dbo.Product", "SubcategoryID", "dbo.Subcategory", "SubcategoryID", cascadeDelete: true);
            DropColumn("dbo.Product", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "SubcategoryID", "dbo.Subcategory");
            DropForeignKey("dbo.Subcategory", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "SubcategoryID" });
            DropIndex("dbo.Subcategory", new[] { "CategoryID" });
            DropColumn("dbo.Product", "SubcategoryID");
            DropTable("dbo.Subcategory");
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
        }
    }
}
