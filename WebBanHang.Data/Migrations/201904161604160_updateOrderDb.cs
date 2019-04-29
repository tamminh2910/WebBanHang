namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "StateID", "dbo.States");
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "StateID" });
            AddColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Orders", "CustomerEmail", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Orders", "CustomerPhone", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "OrderID");
            DropColumn("dbo.Orders", "EmployeeID");
            DropColumn("dbo.Orders", "StateID");
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StateID);
            
            AddColumn("dbo.Orders", "StateID", c => c.Int());
            AddColumn("dbo.Orders", "EmployeeID", c => c.Int());
            AddColumn("dbo.Customers", "OrderID", c => c.Int());
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "CustomerPhone");
            DropColumn("dbo.Orders", "CustomerEmail");
            DropColumn("dbo.Orders", "CustomerAddress");
            DropColumn("dbo.Orders", "CustomerName");
            CreateIndex("dbo.Orders", "StateID");
            CreateIndex("dbo.Orders", "EmployeeID");
            AddForeignKey("dbo.Orders", "StateID", "dbo.States", "StateID");
            AddForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees", "EmployeeID");
        }
    }
}
