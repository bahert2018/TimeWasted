namespace TimeWasted.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        WatchedIt = c.Boolean(nullable: false),
                        Sequel = c.Int(nullable: false),
                        WatchLater = c.Boolean(nullable: false),
                        WorthIt = c.Boolean(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        ShowId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AllShows", t => t.ShowId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ShowId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Users", "ShowId", "dbo.AllShows");
            DropIndex("dbo.Users", new[] { "MovieId" });
            DropIndex("dbo.Users", new[] { "ShowId" });
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
        }
    }
}
