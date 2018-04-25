namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumee3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.WorkExperiences", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            DropIndex("dbo.WorkExperiences", new[] { "Resume_ID" });
            DropColumn("dbo.EducationBackgrounds", "ResumeId");
            DropColumn("dbo.WorkExperiences", "ResumeId");
            RenameColumn(table: "dbo.EducationBackgrounds", name: "Resume_ID", newName: "ResumeId");
            RenameColumn(table: "dbo.WorkExperiences", name: "Resume_ID", newName: "ResumeId");
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Long(nullable: false));
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Long(nullable: false));
            AlterColumn("dbo.WorkExperiences", "ResumeId", c => c.Long(nullable: false));
            AlterColumn("dbo.WorkExperiences", "ResumeId", c => c.Long(nullable: false));
            CreateIndex("dbo.EducationBackgrounds", "ResumeId");
            CreateIndex("dbo.WorkExperiences", "ResumeId");
            AddForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkExperiences", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.WorkExperiences", new[] { "ResumeId" });
            DropIndex("dbo.EducationBackgrounds", new[] { "ResumeId" });
            AlterColumn("dbo.WorkExperiences", "ResumeId", c => c.Long());
            AlterColumn("dbo.WorkExperiences", "ResumeId", c => c.Int(nullable: false));
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Long());
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.WorkExperiences", name: "ResumeId", newName: "Resume_ID");
            RenameColumn(table: "dbo.EducationBackgrounds", name: "ResumeId", newName: "Resume_ID");
            AddColumn("dbo.WorkExperiences", "ResumeId", c => c.Int(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkExperiences", "Resume_ID");
            CreateIndex("dbo.EducationBackgrounds", "Resume_ID");
            AddForeignKey("dbo.WorkExperiences", "Resume_ID", "dbo.Resumes", "ID");
            AddForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes", "ID");
        }
    }
}
