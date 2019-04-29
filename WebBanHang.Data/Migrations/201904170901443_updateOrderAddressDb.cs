namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderAddressDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "CustomerAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
