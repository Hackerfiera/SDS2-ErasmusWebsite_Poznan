namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Degree_DegreeID", c => c.Int());
            CreateIndex("dbo.Courses", "Degree_DegreeID");
            AddForeignKey("dbo.Courses", "Degree_DegreeID", "dbo.Degrees", "DegreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Degree_DegreeID", "dbo.Degrees");
            DropIndex("dbo.Courses", new[] { "Degree_DegreeID" });
            DropColumn("dbo.Courses", "Degree_DegreeID");
        }
    }
}
