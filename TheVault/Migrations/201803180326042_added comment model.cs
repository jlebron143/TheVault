namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcommentmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        UserID = c.String(),
                        MessageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Messages", t => t.MessageID, cascadeDelete: true)
                .Index(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "MessageID", "dbo.Messages");
            DropIndex("dbo.Comments", new[] { "MessageID" });
            DropTable("dbo.Comments");
        }
    }
}
