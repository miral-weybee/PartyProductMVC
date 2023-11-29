namespace PartyProductMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignpartychanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AssignParties", name: "Party_PartyId", newName: "PartyId");
            RenameColumn(table: "dbo.AssignParties", name: "Product_ProductId", newName: "ProductId");
            RenameIndex(table: "dbo.AssignParties", name: "IX_Party_PartyId", newName: "IX_PartyId");
            RenameIndex(table: "dbo.AssignParties", name: "IX_Product_ProductId", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AssignParties", name: "IX_ProductId", newName: "IX_Product_ProductId");
            RenameIndex(table: "dbo.AssignParties", name: "IX_PartyId", newName: "IX_Party_PartyId");
            RenameColumn(table: "dbo.AssignParties", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.AssignParties", name: "PartyId", newName: "Party_PartyId");
        }
    }
}
