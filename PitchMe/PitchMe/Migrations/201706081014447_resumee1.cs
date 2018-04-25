namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "DateOfBirth");
        }
    }
}
