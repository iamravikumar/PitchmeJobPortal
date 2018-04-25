namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealingWithSubscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationBackgrounds", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobSubscriptions", "NumberOfMonths", c => c.Int(nullable: false));
            AddColumn("dbo.JobSubscriptions", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSubscriptions", "PhoneNumber");
            DropColumn("dbo.JobSubscriptions", "NumberOfMonths");
            DropColumn("dbo.WorkExperiences", "EndDate");
            DropColumn("dbo.WorkExperiences", "StartDate");
            DropColumn("dbo.EducationBackgrounds", "EndDate");
            DropColumn("dbo.EducationBackgrounds", "StartDate");
        }
    }
}
