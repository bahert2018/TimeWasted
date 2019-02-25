namespace TimeWasted.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieLength", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "TimeTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "TimeTotal");
            DropColumn("dbo.Movies", "MovieLength");
        }
    }
}
