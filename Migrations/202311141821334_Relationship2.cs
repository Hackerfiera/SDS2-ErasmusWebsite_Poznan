namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Degree_DegreeID", "dbo.Degrees");
            DropIndex("dbo.Courses", new[] { "Degree_DegreeID" });
            AddColumn("dbo.Courses", "DegreeID", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Degree_DegreeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Degree_DegreeID", c => c.Int());
            DropColumn("dbo.Courses", "DegreeID");
            CreateIndex("dbo.Courses", "Degree_DegreeID");
            AddForeignKey("dbo.Courses", "Degree_DegreeID", "dbo.Degrees", "DegreeID");
        }
    }
}
