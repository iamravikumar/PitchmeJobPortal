namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResumeNoni : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resumes", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resumes", "Gender", c => c.Int(nullable: false));
        }
    }
}
