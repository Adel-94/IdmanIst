namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wishes", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Wishes", new[] { "Product_ProductId" });
            DropColumn("dbo.Wishes", "product_id");
            RenameColumn(table: "dbo.Wishes", name: "Product_ProductId", newName: "product_id");
            AlterColumn("dbo.Wishes", "product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Wishes", "product_id");
            AddForeignKey("dbo.Wishes", "product_id", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishes", "product_id", "dbo.Product");
            DropIndex("dbo.Wishes", new[] { "product_id" });
            AlterColumn("dbo.Wishes", "product_id", c => c.Int());
            RenameColumn(table: "dbo.Wishes", name: "product_id", newName: "Product_ProductId");
            AddColumn("dbo.Wishes", "product_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Wishes", "Product_ProductId");
            AddForeignKey("dbo.Wishes", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}
