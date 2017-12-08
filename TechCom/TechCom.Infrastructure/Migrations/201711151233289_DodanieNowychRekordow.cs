namespace TechCom.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieNowychRekordow : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderDetail", name: "ApplicationUser_Id", newName: "UserID");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_ApplicationUser_Id", newName: "IX_UserID");
            AddColumn("dbo.OrderDetail", "Adress", c => c.String());
            AddColumn("dbo.OrderDetail", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_ZipCode", c => c.String());
            DropColumn("dbo.OrderDetail", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "Street", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_ZipCode");
            DropColumn("dbo.OrderDetail", "Email");
            DropColumn("dbo.OrderDetail", "Adress");
            RenameIndex(table: "dbo.OrderDetail", name: "IX_UserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.OrderDetail", name: "UserID", newName: "ApplicationUser_Id");
        }
    }
}
