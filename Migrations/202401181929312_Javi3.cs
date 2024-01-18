namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Javi3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ECTS", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ECTSCardURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ECTSCardURL");
            DropColumn("dbo.Courses", "ECTS");
        }
    }
}
