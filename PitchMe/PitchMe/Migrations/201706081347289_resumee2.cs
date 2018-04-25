namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumee2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "NumberOfApplicants", c => c.Int(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkExperiences", "ResumeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkExperiences", "ResumeId");
            DropColumn("dbo.EducationBackgrounds", "ResumeId");
            DropColumn("dbo.Jobs", "NumberOfApplicants");
        }
    }
}
