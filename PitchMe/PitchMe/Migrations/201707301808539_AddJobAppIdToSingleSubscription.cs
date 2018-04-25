namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobAppIdToSingleSubscription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Subscriptions", "JobApplicationId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "JobApplicationId");
            DropColumn("dbo.Subscriptions", "Amount");
        }
    }
}
