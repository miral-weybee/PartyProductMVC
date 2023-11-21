namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignparty4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignParties", "Party_PartyId", c => c.Int(nullable: false));
            AddColumn("dbo.AssignParties", "Product_ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.AssignParties", "Party_PartyId");
            CreateIndex("dbo.AssignParties", "Product_ProductId");
            AddForeignKey("dbo.AssignParties", "Party_PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
            AddForeignKey("dbo.AssignParties", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.AssignParties", "Party");
            DropColumn("dbo.AssignParties", "Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignParties", "Product", c => c.String(nullable: false));
            AddColumn("dbo.AssignParties", "Party", c => c.String(nullable: false));
            DropForeignKey("dbo.AssignParties", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.AssignParties", "Party_PartyId", "dbo.Parties");
            DropIndex("dbo.AssignParties", new[] { "Product_ProductId" });
            DropIndex("dbo.AssignParties", new[] { "Party_PartyId" });
            DropColumn("dbo.AssignParties", "Product_ProductId");
            DropColumn("dbo.AssignParties", "Party_PartyId");
        }
    }
}
