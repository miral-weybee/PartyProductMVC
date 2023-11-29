namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Invoices", "PartyId");
            CreateIndex("dbo.Invoices", "ProductId");
            AddForeignKey("dbo.Invoices", "PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "PartyId", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "PartyId" });
        }
    }
}
