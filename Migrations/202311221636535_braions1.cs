namespace ErasmusSDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class braions1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LAs", "NombreEstudiante", c => c.String());
            AddColumn("dbo.LAs", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LAs", "status");
            DropColumn("dbo.LAs", "NombreEstudiante");
        }
    }
}
