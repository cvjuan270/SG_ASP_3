namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aptituds",
                c => new
                    {
                        IdApti = c.Int(nullable: false, identity: true),
                        Descri = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdApti);
            
            CreateTable(
                "dbo.ExaMedicoes",
                c => new
                    {
                        IdExMed = c.Int(nullable: false, identity: true),
                        Examen = c.String(),
                    })
                .PrimaryKey(t => t.IdExMed);
            
            CreateTable(
                "dbo.Auditorias",
                c => new
                    {
                        IdAudi = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        ExaCom = c.Boolean(nullable: false),
                        ExaCom1 = c.String(maxLength: 20),
                        DatInc = c.Boolean(nullable: false),
                        DatInc1 = c.String(maxLength: 20),
                        AptErr = c.Boolean(nullable: false),
                        AptErr1 = c.String(maxLength: 20),
                        FaFiMe = c.Boolean(nullable: false),
                        FaFiMe1 = c.String(maxLength: 20),
                        FaFiPa = c.Boolean(nullable: false),
                        FaFiPa1 = c.String(maxLength: 20),
                        Restri = c.Boolean(nullable: false),
                        Restri1 = c.String(maxLength: 20),
                        Contro = c.Boolean(nullable: false),
                        Contro1 = c.String(maxLength: 20),
                        Diagno = c.Boolean(nullable: false),
                        Diagno1 = c.String(maxLength: 20),
                        ErrLle = c.Boolean(nullable: false),
                        ErrLle1 = c.String(maxLength: 20),
                        ObNoRe = c.String(maxLength: 100),
                        EmSnOb = c.Boolean(nullable: false),
                        EmSnOb1 = c.String(maxLength: 20),
                        HorAud = c.Time(precision: 7),
                        FecAud = c.DateTime(storeType: "date"),
                        UserName = c.String(maxLength: 100),
                        IdMedico = c.Int(nullable: false),
                        OmiInt = c.Boolean(nullable: false),
                        OmiInt1 = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdAudi)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.IdMedico, cascadeDelete: true)
                .Index(t => t.IdAtenciones)
                .Index(t => t.IdMedico);
            
            CreateTable(
                "dbo.Atenciones",
                c => new
                    {
                        IdAtenciones = c.Int(nullable: false, identity: true),
                        Local0 = c.String(maxLength: 20),
                        TipExa = c.String(maxLength: 20),
                        FecAte = c.DateTime(storeType: "date"),
                        NomApe = c.String(maxLength: 100),
                        DocIde = c.String(maxLength: 20),
                        Empres = c.String(maxLength: 100),
                        SubCon = c.String(maxLength: 100),
                        Proyec = c.String(maxLength: 100),
                        Perfil = c.String(maxLength: 100),
                        Area = c.String(maxLength: 100),
                        PueTra = c.String(maxLength: 100),
                        PeReAd = c.String(maxLength: 50),
                        Hora = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.IdAtenciones);
            
            CreateTable(
                "dbo.Admisions",
                c => new
                    {
                        IdAdmi = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        HorIng = c.Time(precision: 7),
                        HorReg = c.Time(precision: 7),
                        HorSal = c.Time(precision: 7),
                        Pendie = c.String(maxLength: 200),
                        EnvAsi = c.Boolean(nullable: false),
                        EnvApt = c.Boolean(nullable: false),
                        FecEnvResMed = c.DateTime(storeType: "date"),
                        FecEnvResEmp = c.DateTime(storeType: "date"),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdAdmi)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .Index(t => t.IdAtenciones);
            
            CreateTable(
                "dbo.Interconsultas",
                c => new
                    {
                        IdInter = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        Descri = c.String(maxLength: 50),
                        FecEnv = c.DateTime(storeType: "date"),
                        PeEnCo = c.String(maxLength: 50),
                        EnHoIn = c.Boolean(nullable: false),
                        FeCoPa = c.DateTime(storeType: "date"),
                        PeCoPa = c.String(maxLength: 50),
                        FeLeObs = c.DateTime(storeType: "date"),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdInter)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .Index(t => t.IdAtenciones);
            
            CreateTable(
                "dbo.Medicinas",
                c => new
                    {
                        IdMedicina = c.Int(nullable: false, identity: true),
                        HorIng = c.Time(precision: 7),
                        HorSal = c.Time(precision: 7),
                        FecApt = c.DateTime(storeType: "date"),
                        FecEnv = c.DateTime(storeType: "date"),
                        Coment = c.String(maxLength: 100),
                        Observ = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 50),
                        IdAtenciones = c.Int(nullable: false),
                        IdMedico = c.Int(nullable: false),
                        IdApti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMedicina)
                .ForeignKey("dbo.Aptituds", t => t.IdApti, cascadeDelete: true)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.IdMedico, cascadeDelete: true)
                .Index(t => t.IdAtenciones)
                .Index(t => t.IdMedico)
                .Index(t => t.IdApti);
            
            CreateTable(
                "dbo.AuditoriaExaMedicoes",
                c => new
                    {
                        Auditoria_IdAudi = c.Int(nullable: false),
                        ExaMedico_IdExMed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Auditoria_IdAudi, t.ExaMedico_IdExMed })
                .ForeignKey("dbo.Auditorias", t => t.Auditoria_IdAudi, cascadeDelete: true)
                .ForeignKey("dbo.ExaMedicoes", t => t.ExaMedico_IdExMed, cascadeDelete: true)
                .Index(t => t.Auditoria_IdAudi)
                .Index(t => t.ExaMedico_IdExMed);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditorias", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.AuditoriaExaMedicoes", "ExaMedico_IdExMed", "dbo.ExaMedicoes");
            DropForeignKey("dbo.AuditoriaExaMedicoes", "Auditoria_IdAudi", "dbo.Auditorias");
            DropForeignKey("dbo.Medicinas", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.Medicinas", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Medicinas", "IdApti", "dbo.Aptituds");
            DropForeignKey("dbo.Interconsultas", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Auditorias", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Admisions", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.AuditoriaExaMedicoes", new[] { "ExaMedico_IdExMed" });
            DropIndex("dbo.AuditoriaExaMedicoes", new[] { "Auditoria_IdAudi" });
            DropIndex("dbo.Medicinas", new[] { "IdApti" });
            DropIndex("dbo.Medicinas", new[] { "IdMedico" });
            DropIndex("dbo.Medicinas", new[] { "IdAtenciones" });
            DropIndex("dbo.Interconsultas", new[] { "IdAtenciones" });
            DropIndex("dbo.Admisions", new[] { "IdAtenciones" });
            DropIndex("dbo.Auditorias", new[] { "IdMedico" });
            DropIndex("dbo.Auditorias", new[] { "IdAtenciones" });
            DropTable("dbo.AuditoriaExaMedicoes");
            DropTable("dbo.Medicinas");
            DropTable("dbo.Interconsultas");
            DropTable("dbo.Admisions");
            DropTable("dbo.Atenciones");
            DropTable("dbo.Auditorias");
            DropTable("dbo.ExaMedicoes");
            DropTable("dbo.Aptituds");
        }
    }
}
