namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeunit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Unit", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Unit");
        }
    }
}
