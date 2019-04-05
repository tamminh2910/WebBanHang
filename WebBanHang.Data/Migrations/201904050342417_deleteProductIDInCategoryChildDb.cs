namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteProductIDInCategoryChildDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CategoryChilds", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryChilds", "ProductID", c => c.Int());
        }
    }
}
