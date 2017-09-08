namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOnlyUserName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "UserName", c => c.String());
            AlterColumn("dbo.Customer", "Password", c => c.String());
            AlterColumn("dbo.Customer", "Email", c => c.String());
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "UserName", c => c.String(nullable: false));
        }
    }
}
