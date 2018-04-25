namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeISsue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resumes", "DateOfBirth");
            DropColumn("dbo.EducationBackgrounds", "StartDate");
            DropColumn("dbo.EducationBackgrounds", "EndDate");
            DropColumn("dbo.WorkExperiences", "StartDate");
            DropColumn("dbo.WorkExperiences", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperiences", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resumes", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
