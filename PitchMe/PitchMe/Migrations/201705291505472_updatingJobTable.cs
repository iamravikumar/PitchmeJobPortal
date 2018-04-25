namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingJobTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "MinimumSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Jobs", "MaximumSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Jobs", "IsSalaryNegotiable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "IsSalaryNegotiable");
            DropColumn("dbo.Jobs", "MaximumSalary");
            DropColumn("dbo.Jobs", "MinimumSalary");
        }
    }
}
