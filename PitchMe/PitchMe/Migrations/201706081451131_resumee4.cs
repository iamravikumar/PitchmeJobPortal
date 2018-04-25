namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumee4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "ResumeId" });
            RenameColumn(table: "dbo.EducationBackgrounds", name: "ResumeId", newName: "Resume_ID");
            AlterColumn("dbo.EducationBackgrounds", "Resume_ID", c => c.Long());
            CreateIndex("dbo.EducationBackgrounds", "Resume_ID");
            AddForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            AlterColumn("dbo.EducationBackgrounds", "Resume_ID", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.EducationBackgrounds", name: "Resume_ID", newName: "ResumeId");
            CreateIndex("dbo.EducationBackgrounds", "ResumeId");
            AddForeignKey("dbo.EducationBackgrounds", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
        }
    }
}
