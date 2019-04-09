namespace WebBanHang.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSupplierDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropColumn("dbo.Products", "SupplierID");
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
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
            
            AddColumn("dbo.Products", "SupplierID", c => c.Int());
            CreateIndex("dbo.Products", "SupplierID");
            AddForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers", "SupplierID");
        }
    }
}
