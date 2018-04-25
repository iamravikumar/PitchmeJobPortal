namespace PitchMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditJobTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "JobCategory_ID", "dbo.JobCategories");
            DropIndex("dbo.Jobs", new[] { "Company_ID" });
            DropIndex("dbo.Jobs", new[] { "JobCategory_ID" });
            RenameColumn(table: "dbo.Jobs", name: "Company_ID", newName: "CompanyId");
            RenameColumn(table: "dbo.Jobs", name: "JobCategory_ID", newName: "JobCategoryId");
            AlterColumn("dbo.Jobs", "CompanyId", c => c.Long(nullable: false));
            AlterColumn("dbo.Jobs", "JobCategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Jobs", "CompanyId");
            CreateIndex("dbo.Jobs", "JobCategoryId");
            AddForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "JobCategoryId", "dbo.JobCategories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobCategoryId", "dbo.JobCategories");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "JobCategoryId" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            AlterColumn("dbo.Jobs", "JobCategoryId", c => c.Long());
            AlterColumn("dbo.Jobs", "CompanyId", c => c.Long());
            RenameColumn(table: "dbo.Jobs", name: "JobCategoryId", newName: "JobCategory_ID");
            RenameColumn(table: "dbo.Jobs", name: "CompanyId", newName: "Company_ID");
            CreateIndex("dbo.Jobs", "JobCategory_ID");
            CreateIndex("dbo.Jobs", "Company_ID");
            AddForeignKey("dbo.Jobs", "JobCategory_ID", "dbo.JobCategories", "ID");
            AddForeignKey("dbo.Jobs", "Company_ID", "dbo.Companies", "ID");
        }
    }
}
