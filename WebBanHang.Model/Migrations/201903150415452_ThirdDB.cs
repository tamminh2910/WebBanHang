namespace WebBanHang.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryChilds", "CategoryParent_CategoryParentID", "dbo.CategoryParents");
            DropIndex("dbo.CategoryChilds", new[] { "CategoryParent_CategoryParentID" });
            DropColumn("dbo.CategoryChilds", "CategoryParent_CategoryParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryChilds", "CategoryParent_CategoryParentID", c => c.Int());
            CreateIndex("dbo.CategoryChilds", "CategoryParent_CategoryParentID");
            AddForeignKey("dbo.CategoryChilds", "CategoryParent_CategoryParentID", "dbo.CategoryParents", "CategoryParentID");
        }
    }
}
