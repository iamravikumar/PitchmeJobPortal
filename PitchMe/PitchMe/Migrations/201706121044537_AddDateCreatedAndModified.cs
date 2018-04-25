namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCreatedAndModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobCategories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resumes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resumes", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Languages", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Languages", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobSubscriptions", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobSubscriptions", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobApplications", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobApplications", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplications", "DateModified");
            DropColumn("dbo.JobApplications", "DateCreated");
            DropColumn("dbo.JobSubscriptions", "DateModified");
            DropColumn("dbo.JobSubscriptions", "DateCreated");
            DropColumn("dbo.WorkExperiences", "DateModified");
            DropColumn("dbo.WorkExperiences", "DateCreated");
            DropColumn("dbo.Languages", "DateModified");
            DropColumn("dbo.Languages", "DateCreated");
            DropColumn("dbo.Resumes", "DateModified");
            DropColumn("dbo.Resumes", "DateCreated");
            DropColumn("dbo.EducationBackgrounds", "DateModified");
            DropColumn("dbo.EducationBackgrounds", "DateCreated");
            DropColumn("dbo.JobCategories", "DateModified");
            DropColumn("dbo.JobCategories", "DateCreated");
            DropColumn("dbo.Jobs", "DateModified");
            DropColumn("dbo.Jobs", "DateCreated");
            DropColumn("dbo.Companies", "DateModified");
            DropColumn("dbo.Companies", "DateCreated");
        }
    }
}
