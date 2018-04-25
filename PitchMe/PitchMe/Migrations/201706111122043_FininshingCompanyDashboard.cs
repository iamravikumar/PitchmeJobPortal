namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FininshingCompanyDashboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobStatus");
        }
    }
}
