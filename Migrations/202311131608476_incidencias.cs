namespace EcoTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incidencias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidencias", "nombre_Compania", c => c.String());
            DropColumn("dbo.Incidencias", "nombre_Compañia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidencias", "nombre_Compañia", c => c.String());
            DropColumn("dbo.Incidencias", "nombre_Compania");
        }
    }
}
