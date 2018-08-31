namespace AnderoTest_461.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SavedDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "SavedDates", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "SavedDates");
        }
    }
}
