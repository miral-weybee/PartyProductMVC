namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentRate = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Party_PartyId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Party_PartyId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Party_PartyId", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "Product_ProductId" });
            DropIndex("dbo.Invoices", new[] { "Party_PartyId" });
            DropTable("dbo.Invoices");
        }
    }
}
