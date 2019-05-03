namespace ShopOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeProductImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductImages", "SwitchImage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductImages", "SwitchImage");
        }
    }
}
