namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Party_PartyId", "dbo.Parties");
            DropForeignKey("dbo.Invoices", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "Party_PartyId" });
            DropIndex("dbo.Invoices", new[] { "Product_ProductId" });
            AddColumn("dbo.Invoices", "PartyId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "Party_PartyId");
            DropColumn("dbo.Invoices", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Product_ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Party_PartyId", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "ProductId");
            DropColumn("dbo.Invoices", "PartyId");
            CreateIndex("dbo.Invoices", "Product_ProductId");
            CreateIndex("dbo.Invoices", "Party_PartyId");
            AddForeignKey("dbo.Invoices", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "Party_PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
        }
    }
}
