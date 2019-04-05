namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AliasDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryChilds", "Alias", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.CategoryParents", "Alias", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Products", "Alias", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Alias");
            DropColumn("dbo.CategoryParents", "Alias");
            DropColumn("dbo.CategoryChilds", "Alias");
        }
    }
}
