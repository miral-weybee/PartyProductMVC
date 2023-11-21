namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productrate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductRates", "ProductName_ProductId", "dbo.Products");
            DropIndex("dbo.ProductRates", new[] { "ProductName_ProductId" });
            AlterColumn("dbo.ProductRates", "ProductName_ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductRates", "ProductName_ProductId");
            AddForeignKey("dbo.ProductRates", "ProductName_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRates", "ProductName_ProductId", "dbo.Products");
            DropIndex("dbo.ProductRates", new[] { "ProductName_ProductId" });
            AlterColumn("dbo.ProductRates", "ProductName_ProductId", c => c.Int());
            CreateIndex("dbo.ProductRates", "ProductName_ProductId");
            AddForeignKey("dbo.ProductRates", "ProductName_ProductId", "dbo.Products", "ProductId");
        }
    }
}
