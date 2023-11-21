namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignparty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignParties",
                c => new
                    {
                        AssignPartyId = c.Int(nullable: false, identity: true),
                        Party_PartyId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignPartyId)
                .ForeignKey("dbo.Parties", t => t.Party_PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Party_PartyId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignParties", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.AssignParties", "Party_PartyId", "dbo.Parties");
            DropIndex("dbo.AssignParties", new[] { "Product_ProductId" });
            DropIndex("dbo.AssignParties", new[] { "Party_PartyId" });
            DropTable("dbo.AssignParties");
        }
    }
}
