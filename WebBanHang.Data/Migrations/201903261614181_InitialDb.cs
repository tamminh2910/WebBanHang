namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryChilds",
                c => new
                    {
                        CategoryChildID = c.Int(nullable: false, identity: true),
                        CategoryChildName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        State = c.Boolean(),
                        CategoryParent_CategoryParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryChildID)
                .ForeignKey("dbo.CategoryParents", t => t.CategoryParent_CategoryParentID)
                .Index(t => t.CategoryParent_CategoryParentID);
            
            CreateTable(
                "dbo.CategoryParents",
                c => new
                    {
                        CategoryParentID = c.Int(nullable: false, identity: true),
                        CategoryParentName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        State = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryParentID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 100),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 100),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Image = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Role_RoleName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Roles", t => t.Role_RoleName)
                .Index(t => t.Role_RoleName);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleName);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        EmployeeID = c.Int(),
                        StateID = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(),
                        ShipAddress = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        SupplierID = c.Int(),
                        Name = c.String(nullable: false, maxLength: 250),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        MoreImages = c.String(storeType: "xml"),
                        RegisterDate = c.DateTime(nullable: false),
                        Discount = c.Int(),
                        Description = c.String(),
                        State = c.Boolean(),
                        CategoryChild_CategoryChildID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.CategoryChilds", t => t.CategoryChild_CategoryChildID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryChild_CategoryChildID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 100),
                        ContactName = c.String(maxLength: 100),
                        ContacTitle = c.String(maxLength: 100),
                        Address = c.String(),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        State = c.Boolean(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryChild_CategoryChildID", "dbo.CategoryChilds");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "StateID", "dbo.States");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Employees", "Role_RoleName", "dbo.Roles");
            DropForeignKey("dbo.CategoryChilds", "CategoryParent_CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.Products", new[] { "CategoryChild_CategoryChildID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Orders", new[] { "StateID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Employees", new[] { "Role_RoleName" });
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParent_CategoryParentID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.States");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Errors");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.CategoryParents");
            DropTable("dbo.CategoryChilds");
        }
    }
}
