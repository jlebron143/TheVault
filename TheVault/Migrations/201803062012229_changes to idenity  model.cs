namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestoidenitymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        UserID = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
