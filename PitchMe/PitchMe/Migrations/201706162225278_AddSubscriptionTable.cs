namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        SubscriptionType = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        SubscriptionExpiration = c.DateTime(),
                        NumberOfMonths = c.Int(),
                        IsActive = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "User_Id", "dbo.Users");
            DropIndex("dbo.Subscriptions", new[] { "User_Id" });
            DropTable("dbo.Subscriptions");
        }
    }
}
