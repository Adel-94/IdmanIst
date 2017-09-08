namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CstmerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerSurName = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhone = c.Int(nullable: false),
                        CustomerPassword = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
