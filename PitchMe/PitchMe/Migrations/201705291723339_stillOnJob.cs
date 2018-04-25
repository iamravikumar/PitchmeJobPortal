namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stillOnJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ExperienceLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "ExperienceLevel");
        }
    }
}
