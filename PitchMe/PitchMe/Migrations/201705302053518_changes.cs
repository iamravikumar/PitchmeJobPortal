namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        pitchLocation = c.String(),
                        cvLocation = c.String(),
                        applicationStatus = c.Int(nullable: false),
                        Subscribed = c.Boolean(nullable: false),
                        job_ID = c.Long(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.job_ID)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.job_ID)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.Jobs", "DatePosted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "JobCategory_ID", c => c.Long());
            CreateIndex("dbo.Jobs", "JobCategory_ID");
            AddForeignKey("dbo.Jobs", "JobCategory_ID", "dbo.JobCategories", "ID");
            DropColumn("dbo.Jobs", "Location");
            DropColumn("dbo.Jobs", "Objectives");
            DropColumn("dbo.Jobs", "MinimumQualification");
            DropColumn("dbo.Jobs", "Specialization");
            DropColumn("dbo.Jobs", "Renumeration");
            DropColumn("dbo.Jobs", "YearsOfExperience");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "YearsOfExperience", c => c.Long(nullable: false));
            AddColumn("dbo.Jobs", "Renumeration", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "Specialization", c => c.String());
            AddColumn("dbo.Jobs", "MinimumQualification", c => c.String());
            AddColumn("dbo.Jobs", "Objectives", c => c.String());
            AddColumn("dbo.Jobs", "Location", c => c.String());
            DropForeignKey("dbo.JobApplications", "user_Id", "dbo.Users");
            DropForeignKey("dbo.JobApplications", "job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "JobCategory_ID", "dbo.JobCategories");
            DropIndex("dbo.JobApplications", new[] { "user_Id" });
            DropIndex("dbo.JobApplications", new[] { "job_ID" });
            DropIndex("dbo.Jobs", new[] { "JobCategory_ID" });
            DropColumn("dbo.Jobs", "JobCategory_ID");
            DropColumn("dbo.Jobs", "DatePosted");
            DropTable("dbo.JobApplications");
        }
    }
}
