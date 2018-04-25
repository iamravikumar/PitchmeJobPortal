namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editted : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "Coy_ID", newName: "Company_ID");
            RenameIndex(table: "dbo.Jobs", name: "IX_Coy_ID", newName: "IX_Company_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Jobs", name: "IX_Company_ID", newName: "IX_Coy_ID");
            RenameColumn(table: "dbo.Jobs", name: "Company_ID", newName: "Coy_ID");
        }
    }
}
