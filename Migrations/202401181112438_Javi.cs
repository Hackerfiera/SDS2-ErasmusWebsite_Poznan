namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Javi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LAs", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LAs", "UserID");
        }
    }
}
