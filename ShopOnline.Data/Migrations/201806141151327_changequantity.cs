namespace ShopOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changequantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.ProductQuantities", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes");
            DropIndex("dbo.OrderDetails", new[] { "SizeId" });
            DropIndex("dbo.ProductQuantities", new[] { "ProductId" });
            DropIndex("dbo.ProductQuantities", new[] { "SizeId" });
            DropTable("dbo.Sizes");
            DropTable("dbo.ProductQuantities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductQuantities",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SizeId });
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.ProductQuantities", "SizeId");
            CreateIndex("dbo.ProductQuantities", "ProductId");
            CreateIndex("dbo.OrderDetails", "SizeId");
            AddForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductQuantities", "ProductId", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes", "ID", cascadeDelete: true);
        }
    }
}
