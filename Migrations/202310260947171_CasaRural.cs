namespace EcoTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CasaRural : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CasaRurals",
                c => new
                    {
                        CasaRuralID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        NumeroPersonas = c.Int(nullable: false),
                        NumeroHabitaciones = c.Int(nullable: false),
                        HayPiscina = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        HayParking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CasaRuralID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CasaRurals");
        }
    }
}
