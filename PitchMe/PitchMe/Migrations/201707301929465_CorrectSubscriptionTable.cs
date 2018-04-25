namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectSubscriptionTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.JobSubscriptions", new[] { "user_Id" });
            DropTable("dbo.JobSubscriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobSubscriptions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        subscriptionDate = c.DateTime(nullable: false),
                        subscriptionExpiration = c.DateTime(),
                        subscriptionType = c.Int(nullable: false),
                        NumberOfMonths = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.JobSubscriptions", "user_Id");
        }
    }
}
