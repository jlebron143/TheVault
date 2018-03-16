namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeditemFKtocarts : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carts", "ItemId");
            AddForeignKey("dbo.Carts", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropIndex("dbo.Carts", new[] { "ItemId" });
        }
    }
}
