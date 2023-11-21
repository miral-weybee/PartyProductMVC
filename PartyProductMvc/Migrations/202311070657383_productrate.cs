namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        DateOfRate = c.DateTime(nullable: false),
                        ProductName_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductName_ProductId)
                .Index(t => t.ProductName_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRates", "ProductName_ProductId", "dbo.Products");
            DropIndex("dbo.ProductRates", new[] { "ProductName_ProductId" });
            DropTable("dbo.ProductRates");
        }
    }
}
