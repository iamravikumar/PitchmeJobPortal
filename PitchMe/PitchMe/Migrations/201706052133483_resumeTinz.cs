namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resumeTinz : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.Users");
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            AddColumn("dbo.Users", "Resume_ID", c => c.Long());
            CreateIndex("dbo.Users", "Resume_ID");
            AddForeignKey("dbo.Users", "Resume_ID", "dbo.Resumes", "ID");
            DropColumn("dbo.Resumes", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resumes", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Users", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.Users", new[] { "Resume_ID" });
            DropColumn("dbo.Users", "Resume_ID");
            CreateIndex("dbo.Resumes", "User_Id");
            AddForeignKey("dbo.Resumes", "User_Id", "dbo.Users", "Id");
        }
    }
}
