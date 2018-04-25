namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumee5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            RenameColumn(table: "dbo.EducationBackgrounds", name: "Resume_ID", newName: "ResumeId");
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Long(nullable: false));
            CreateIndex("dbo.EducationBackgrounds", "ResumeId");
            AddForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "ResumeId" });
            AlterColumn("dbo.EducationBackgrounds", "ResumeId", c => c.Long());
            RenameColumn(table: "dbo.EducationBackgrounds", name: "ResumeId", newName: "Resume_ID");
            CreateIndex("dbo.EducationBackgrounds", "Resume_ID");
            AddForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes", "ID");
        }
    }
}
