namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeResumeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        AdditionalInformation = c.String(),
                        ProfileImageUri = c.String(),
                        CareerObjective = c.String(),
                        SkillsAndQualifications = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Nationality = c.String(),
                        Address = c.String(),
                        Declaration = c.String(),
                        Gender = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EducationBackgrounds",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        InstitutionNamme = c.String(),
                        DegreeAwarded = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Resume_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.Resume_ID)
                .Index(t => t.Resume_ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        Resume_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.Resume_ID)
                .Index(t => t.Resume_ID);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Designation = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        JobDescription = c.String(),
                        Resume_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.Resume_ID)
                .Index(t => t.Resume_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Languages", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.WorkExperiences", new[] { "Resume_ID" });
            DropIndex("dbo.Languages", new[] { "Resume_ID" });
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Languages");
            DropTable("dbo.EducationBackgrounds");
            DropTable("dbo.Resumes");
        }
    }
}
