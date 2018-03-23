namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrecipientID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "RecipientID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "RecipientID");
        }
    }
}
