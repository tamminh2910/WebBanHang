namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryChilds", "CategoryParent_CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParent_CategoryParentID" });
            RenameColumn(table: "dbo.CategoryChilds", name: "CategoryParent_CategoryParentID", newName: "CategoryParentID");
            AddColumn("dbo.CategoryChilds", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.CategoryChilds", "CategoryParentID", c => c.Int(nullable: false));
            CreateIndex("dbo.CategoryChilds", "CategoryParentID");
            AddForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents", "CategoryParentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryChilds", "CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParentID" });
            AlterColumn("dbo.CategoryChilds", "CategoryParentID", c => c.Int());
            DropColumn("dbo.CategoryChilds", "ProductID");
            RenameColumn(table: "dbo.CategoryChilds", name: "CategoryParentID", newName: "CategoryParent_CategoryParentID");
            CreateIndex("dbo.CategoryChilds", "CategoryParent_CategoryParentID");
            AddForeignKey("dbo.CategoryChilds", "CategoryParent_CategoryParentID", "dbo.CategoryParents", "CategoryParentID");
        }
    }
}
