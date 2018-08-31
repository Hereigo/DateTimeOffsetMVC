namespace AnderoTest_461.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedDates_NorRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "SavedDates", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "SavedDates", c => c.String(nullable: false));
        }
    }
}
