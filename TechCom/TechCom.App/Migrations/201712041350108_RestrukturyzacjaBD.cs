namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestrukturyzacjaBD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserData_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Email", c => c.String());
        }
    }
}
