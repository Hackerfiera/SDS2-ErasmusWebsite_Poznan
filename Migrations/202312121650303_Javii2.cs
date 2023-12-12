namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Javii2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LAs", "CourseList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LAs", "CourseList");
        }
    }
}
