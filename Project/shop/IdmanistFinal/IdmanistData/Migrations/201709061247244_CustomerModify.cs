namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModify : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customer");
            AddColumn("dbo.Customer", "UserID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customer", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Customer", "UserID");
            DropColumn("dbo.Customer", "CustomerId");
            DropColumn("dbo.Customer", "CustomerName");
            DropColumn("dbo.Customer", "CustomerSurName");
            DropColumn("dbo.Customer", "CustomerEmail");
            DropColumn("dbo.Customer", "CustomerPhone");
            DropColumn("dbo.Customer", "CustomerPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CustomerPassword", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CustomerPhone", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "CustomerEmail", c => c.String());
            AddColumn("dbo.Customer", "CustomerSurName", c => c.String());
            AddColumn("dbo.Customer", "CustomerName", c => c.String());
            AddColumn("dbo.Customer", "CustomerId", c => c.Int(nullable: false, identity: false));
            DropPrimaryKey("dbo.Customer");
            DropColumn("dbo.Customer", "Email");
            DropColumn("dbo.Customer", "LastName");
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "ConfirmPassword");
            DropColumn("dbo.Customer", "Password");
            DropColumn("dbo.Customer", "UserName");
            DropColumn("dbo.Customer", "UserID");
            AddPrimaryKey("dbo.Customer", "CustomerId");
        }
    }
}
