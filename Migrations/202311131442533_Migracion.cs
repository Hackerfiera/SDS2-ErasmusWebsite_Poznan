namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        DegreeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DegreeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Degrees");
        }
    }
}
