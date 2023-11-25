namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class braions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LAs",
                c => new
                    {
                        LAID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LAID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LAs");
        }
    }
}
