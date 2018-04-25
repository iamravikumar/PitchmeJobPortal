namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stillOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Title", c => c.String());
            DropColumn("dbo.Jobs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Name", c => c.String());
            DropColumn("dbo.Jobs", "Title");
        }
    }
}
