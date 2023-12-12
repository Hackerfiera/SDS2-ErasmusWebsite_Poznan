namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anyels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "LA_LAID", "dbo.LAs");
            DropIndex("dbo.Courses", new[] { "LA_LAID" });
            DropColumn("dbo.Courses", "LA_LAID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "LA_LAID", c => c.Int());
            CreateIndex("dbo.Courses", "LA_LAID");
            AddForeignKey("dbo.Courses", "LA_LAID", "dbo.LAs", "LAID");
        }
    }
}
