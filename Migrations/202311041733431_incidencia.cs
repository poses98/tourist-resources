namespace EcoTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incidencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilleteTrens",
                c => new
                    {
                        IdBilleteTren = c.Int(nullable: false, identity: true),
                        Compania = c.Int(nullable: false),
                        TipoTren = c.Int(nullable: false),
                        Origen = c.String(),
                        Destino = c.String(),
                        HayCafeteria = c.Boolean(nullable: false),
                        NumeroPlazas = c.Int(nullable: false),
                        Fecha = c.String(),
                        HoraSalida = c.String(),
                        HoraLlegada = c.String(),
                    })
                .PrimaryKey(t => t.IdBilleteTren);
            
            CreateTable(
                "dbo.Campings",
                c => new
                    {
                        CampingId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                        NumeroPlazas = c.Int(nullable: false),
                        NumeroBungalows = c.Int(nullable: false),
                        HayPiscina = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CampingId);
            
            CreateTable(
                "dbo.CasaRurals",
                c => new
                    {
                        CasaRuralID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        NumeroPersonas = c.Int(nullable: false),
                        NumeroHabitaciones = c.Int(nullable: false),
                        ActividadesRuralesCerca = c.String(),
                        HayPiscina = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        HayParking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CasaRuralID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        NumeroEstrellas = c.Int(nullable: false),
                        Rural = c.Boolean(nullable: false),
                        Mascotas = c.Boolean(nullable: false),
                        SoloAdultos = c.Boolean(nullable: false),
                        Tematico = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        Parking = c.Boolean(nullable: false),
                        NumeroHabitaciones = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.Incidencias",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        tipo_Recurso = c.Int(nullable: false),
                        nombre_Compañia = c.String(),
                        descripcion = c.String(),
                        grevedad = c.Int(nullable: false),
                        opinion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Incidencias");
            DropTable("dbo.Hotels");
            DropTable("dbo.CasaRurals");
            DropTable("dbo.Campings");
            DropTable("dbo.BilleteTrens");
        }
    }
}
