namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "ProfileImageUri", c => c.String());
            AlterColumn("dbo.Subscriptions", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "PhoneNumber", c => c.String());
            DropColumn("dbo.Companies", "ProfileImageUri");
        }
    }
}
