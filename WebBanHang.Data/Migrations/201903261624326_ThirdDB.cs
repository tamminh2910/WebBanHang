namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParentID" });
            RenameColumn(table: "dbo.Employees", name: "Role_RoleName", newName: "RoleName");
            RenameColumn(table: "dbo.Products", name: "CategoryChild_CategoryChildID", newName: "CategoryChildID");
            RenameIndex(table: "dbo.Employees", name: "IX_Role_RoleName", newName: "IX_RoleName");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryChild_CategoryChildID", newName: "IX_CategoryChildID");
            AddColumn("dbo.Customers", "OrderID", c => c.Int());
            AddColumn("dbo.Suppliers", "ProductID", c => c.Int());
            AlterColumn("dbo.CategoryChilds", "CategoryParentID", c => c.Int());
            AlterColumn("dbo.CategoryChilds", "ProductID", c => c.Int());
            CreateIndex("dbo.CategoryChilds", "CategoryParentID");
            AddForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents", "CategoryParentID");
            DropColumn("dbo.Products", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            DropForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParentID" });
            AlterColumn("dbo.CategoryChilds", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.CategoryChilds", "CategoryParentID", c => c.Int(nullable: false));
            DropColumn("dbo.Suppliers", "ProductID");
            DropColumn("dbo.Customers", "OrderID");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryChildID", newName: "IX_CategoryChild_CategoryChildID");
            RenameIndex(table: "dbo.Employees", name: "IX_RoleName", newName: "IX_Role_RoleName");
            RenameColumn(table: "dbo.Products", name: "CategoryChildID", newName: "CategoryChild_CategoryChildID");
            RenameColumn(table: "dbo.Employees", name: "RoleName", newName: "Role_RoleName");
            CreateIndex("dbo.CategoryChilds", "CategoryParentID");
            AddForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents", "CategoryParentID", cascadeDelete: true);
        }
    }
}
