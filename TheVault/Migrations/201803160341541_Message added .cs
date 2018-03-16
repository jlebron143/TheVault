namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messageadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "UserID");
        }
    }
}
