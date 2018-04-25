namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementLanguageInResume : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Languages", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.Languages", new[] { "Resume_ID" });
            RenameColumn(table: "dbo.Languages", name: "Resume_ID", newName: "ResumeId");
            AlterColumn("dbo.Languages", "ResumeId", c => c.Long(nullable: false));
            CreateIndex("dbo.Languages", "ResumeId");
            AddForeignKey("dbo.Languages", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Languages", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Languages", new[] { "ResumeId" });
            AlterColumn("dbo.Languages", "ResumeId", c => c.Long());
            RenameColumn(table: "dbo.Languages", name: "ResumeId", newName: "Resume_ID");
            CreateIndex("dbo.Languages", "Resume_ID");
            AddForeignKey("dbo.Languages", "Resume_ID", "dbo.Resumes", "ID");
        }
    }
}
