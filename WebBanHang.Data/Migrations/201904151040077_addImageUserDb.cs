namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageUserDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Image");
        }
    }
}
