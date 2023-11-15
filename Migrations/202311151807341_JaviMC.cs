namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JaviMC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Information", c => c.String());
            AddColumn("dbo.Degrees", "Information", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Degrees", "Information");
            DropColumn("dbo.Courses", "Information");
        }
    }
}
