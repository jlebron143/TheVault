namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabasewithchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Producer_ProducerID", "dbo.Producers");
            DropIndex("dbo.Items", new[] { "Producer_ProducerID" });
            RenameColumn(table: "dbo.Items", name: "Producer_ProducerID", newName: "ProducerId");
            AlterColumn("dbo.Items", "Title", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.String(maxLength: 1024));
            AlterColumn("dbo.Items", "ProducerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ProducerId");
            AddForeignKey("dbo.Items", "ProducerId", "dbo.Producers", "ProducerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ProducerId", "dbo.Producers");
            DropIndex("dbo.Items", new[] { "ProducerId" });
            AlterColumn("dbo.Items", "ProducerId", c => c.Int());
            AlterColumn("dbo.Items", "ItemArtUrl", c => c.String());
            AlterColumn("dbo.Items", "Title", c => c.String());
            RenameColumn(table: "dbo.Items", name: "ProducerId", newName: "Producer_ProducerID");
            CreateIndex("dbo.Items", "Producer_ProducerID");
            AddForeignKey("dbo.Items", "Producer_ProducerID", "dbo.Producers", "ProducerID");
        }
    }
}
