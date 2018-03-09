namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Comment = c.String(maxLength: 509),
                        YourName = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
