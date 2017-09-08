namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Customer", "Password", c => c.String());
        }
    }
}
