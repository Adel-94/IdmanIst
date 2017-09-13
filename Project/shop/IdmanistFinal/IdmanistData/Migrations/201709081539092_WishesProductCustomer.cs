namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishesProductCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        wished = c.Boolean(nullable: false),
                        product_id = c.Int(nullable: false),
                        customer_id = c.Int(nullable: false),
                        Customer_UserID = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customer", t => t.Customer_UserID)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Customer_UserID)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishes", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Wishes", "Customer_UserID", "dbo.Customer");
            DropIndex("dbo.Wishes", new[] { "Product_ProductId" });
            DropIndex("dbo.Wishes", new[] { "Customer_UserID" });
            DropTable("dbo.Wishes");
        }
    }
}
