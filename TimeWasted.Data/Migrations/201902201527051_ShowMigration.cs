namespace TimeWasted.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Times", newName: "AllShows");
            AddColumn("dbo.AllShows", "TotalTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AllShows", "TotalTime");
            RenameTable(name: "dbo.AllShows", newName: "Times");
        }
    }
}
