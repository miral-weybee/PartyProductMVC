namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignparty3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignParties", "Party_PartyId", "dbo.Parties");
            DropForeignKey("dbo.AssignParties", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.AssignParties", new[] { "Party_PartyId" });
            DropIndex("dbo.AssignParties", new[] { "Product_ProductId" });
            AddColumn("dbo.AssignParties", "Party", c => c.String(nullable: false));
            AddColumn("dbo.AssignParties", "Product", c => c.String(nullable: false));
            DropColumn("dbo.AssignParties", "Party_PartyId");
            DropColumn("dbo.AssignParties", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignParties", "Product_ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.AssignParties", "Party_PartyId", c => c.Int(nullable: false));
            DropColumn("dbo.AssignParties", "Product");
            DropColumn("dbo.AssignParties", "Party");
            CreateIndex("dbo.AssignParties", "Product_ProductId");
            CreateIndex("dbo.AssignParties", "Party_PartyId");
            AddForeignKey("dbo.AssignParties", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.AssignParties", "Party_PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
        }
    }
}
