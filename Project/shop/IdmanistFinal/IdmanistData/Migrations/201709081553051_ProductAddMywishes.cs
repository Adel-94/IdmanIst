namespace IdmanistData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddMywishes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "mywishes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "mywishes");
        }
    }
}
