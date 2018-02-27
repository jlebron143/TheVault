namespace TheVault.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Title = c.String(),
                        Message = c.String(maxLength: 509),
                        Image = c.String(),
                        New = c.Boolean(nullable: false),
                        Used = c.Boolean(nullable: false),
                        UserID = c.String(),
                        ShoeBrandID = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.ShoeBrands", t => t.ShoeBrandID, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ShoeBrandID)
                .Index(t => t.SizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Posts", "ShoeBrandID", "dbo.ShoeBrands");
            DropIndex("dbo.Posts", new[] { "SizeId" });
            DropIndex("dbo.Posts", new[] { "ShoeBrandID" });
            DropTable("dbo.Posts");
        }
    }
}
