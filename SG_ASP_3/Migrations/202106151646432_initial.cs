namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                        AleMed = c.Int(),
                        AleAud = c.Int(),
                        AleEnf = c.Int(),
                    })
                .PrimaryKey(t => t.IdAtenciones);
            
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
                "dbo.ExaMedicoes",
                c => new
                    {
                        IdExMed = c.Int(nullable: false, identity: true),
                        Examen = c.String(),
                    })
                .PrimaryKey(t => t.IdExMed);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        IdMedico = c.Int(nullable: false, identity: true),
                        NomApe = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdMedico);
            
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
                "dbo.Aptituds",
                c => new
                    {
                        IdApti = c.Int(nullable: false, identity: true),
                        Descri = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdApti);
            
            CreateTable(
                "dbo.AtenciCovs",
                c => new
                    {
                        IdAteCov = c.Int(nullable: false, identity: true),
                        FecTomMue = c.DateTime(nullable: false, storeType: "date"),
                        HorTomMue = c.Time(nullable: false, precision: 7),
                        IdDocIde = c.Int(nullable: false),
                        NumDocIde = c.String(),
                        NomApe = c.String(),
                        IdTipPru = c.Int(nullable: false),
                        IdRes = c.Int(nullable: false),
                        ResultAg_IdResAg = c.Int(),
                        ResultCua_IdResCua = c.Int(),
                        ResultMol_IdResMol = c.Int(),
                        ResultSer_IdResSer = c.Int(),
                    })
                .PrimaryKey(t => t.IdAteCov)
                .ForeignKey("dbo.DocIdes", t => t.IdDocIde, cascadeDelete: true)
                .ForeignKey("dbo.ResultAgs", t => t.ResultAg_IdResAg)
                .ForeignKey("dbo.ResultCuas", t => t.ResultCua_IdResCua)
                .ForeignKey("dbo.ResultMols", t => t.ResultMol_IdResMol)
                .ForeignKey("dbo.ResultSers", t => t.ResultSer_IdResSer)
                .ForeignKey("dbo.TipoPruebas", t => t.IdTipPru, cascadeDelete: true)
                .Index(t => t.IdDocIde)
                .Index(t => t.IdTipPru)
                .Index(t => t.ResultAg_IdResAg)
                .Index(t => t.ResultCua_IdResCua)
                .Index(t => t.ResultMol_IdResMol)
                .Index(t => t.ResultSer_IdResSer);
            
            CreateTable(
                "dbo.DocIdes",
                c => new
                    {
                        IdDocIde = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Descri = c.String(),
                    })
                .PrimaryKey(t => t.IdDocIde);
            
            CreateTable(
                "dbo.ResultAgs",
                c => new
                    {
                        IdResAg = c.Int(nullable: false, identity: true),
                        IdAteCov = c.Int(nullable: false),
                        Ag = c.Boolean(nullable: false),
                        R = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdResAg);
            
            CreateTable(
                "dbo.ResultCuas",
                c => new
                    {
                        IdResCua = c.Int(nullable: false, identity: true),
                        IdAteCov = c.Int(nullable: false),
                        Igg = c.Int(nullable: false),
                        Igm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdResCua);
            
            CreateTable(
                "dbo.ResultMols",
                c => new
                    {
                        IdResMol = c.Int(nullable: false, identity: true),
                        IdAteCov = c.Int(nullable: false),
                        Result = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdResMol);
            
            CreateTable(
                "dbo.ResultSers",
                c => new
                    {
                        IdResSer = c.Int(nullable: false, identity: true),
                        IdAteCov = c.Int(nullable: false),
                        Igg = c.Boolean(nullable: false),
                        Igm = c.Int(nullable: false),
                        R = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdResSer);
            
            CreateTable(
                "dbo.TipoPruebas",
                c => new
                    {
                        IdTipPru = c.Int(nullable: false, identity: true),
                        Descri = c.String(),
                    })
                .PrimaryKey(t => t.IdTipPru);
            
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
            
            CreateTable(
                "dbo.ExaMedicoAuditorias",
                c => new
                    {
                        ExaMedico_IdExMed = c.Int(nullable: false),
                        Auditoria_IdAudi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExaMedico_IdExMed, t.Auditoria_IdAudi })
                .ForeignKey("dbo.ExaMedicoes", t => t.ExaMedico_IdExMed, cascadeDelete: true)
                .ForeignKey("dbo.Auditorias", t => t.Auditoria_IdAudi, cascadeDelete: true)
                .Index(t => t.ExaMedico_IdExMed)
                .Index(t => t.Auditoria_IdAudi);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AtenciCovs", "IdTipPru", "dbo.TipoPruebas");
            DropForeignKey("dbo.AtenciCovs", "ResultSer_IdResSer", "dbo.ResultSers");
            DropForeignKey("dbo.AtenciCovs", "ResultMol_IdResMol", "dbo.ResultMols");
            DropForeignKey("dbo.AtenciCovs", "ResultCua_IdResCua", "dbo.ResultCuas");
            DropForeignKey("dbo.AtenciCovs", "ResultAg_IdResAg", "dbo.ResultAgs");
            DropForeignKey("dbo.AtenciCovs", "IdDocIde", "dbo.DocIdes");
            DropForeignKey("dbo.Medicinas", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.Medicinas", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Medicinas", "IdApti", "dbo.Aptituds");
            DropForeignKey("dbo.Interconsultas", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Auditorias", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.ExaMedicoAuditorias", "Auditoria_IdAudi", "dbo.Auditorias");
            DropForeignKey("dbo.ExaMedicoAuditorias", "ExaMedico_IdExMed", "dbo.ExaMedicoes");
            DropForeignKey("dbo.Auditorias", "IdAtenciones", "dbo.Atenciones");
            DropForeignKey("dbo.Admisions", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.ExaMedicoAuditorias", new[] { "Auditoria_IdAudi" });
            DropIndex("dbo.ExaMedicoAuditorias", new[] { "ExaMedico_IdExMed" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AtenciCovs", new[] { "ResultSer_IdResSer" });
            DropIndex("dbo.AtenciCovs", new[] { "ResultMol_IdResMol" });
            DropIndex("dbo.AtenciCovs", new[] { "ResultCua_IdResCua" });
            DropIndex("dbo.AtenciCovs", new[] { "ResultAg_IdResAg" });
            DropIndex("dbo.AtenciCovs", new[] { "IdTipPru" });
            DropIndex("dbo.AtenciCovs", new[] { "IdDocIde" });
            DropIndex("dbo.Medicinas", new[] { "IdApti" });
            DropIndex("dbo.Medicinas", new[] { "IdMedico" });
            DropIndex("dbo.Medicinas", new[] { "IdAtenciones" });
            DropIndex("dbo.Interconsultas", new[] { "IdAtenciones" });
            DropIndex("dbo.Auditorias", new[] { "IdMedico" });
            DropIndex("dbo.Auditorias", new[] { "IdAtenciones" });
            DropIndex("dbo.Admisions", new[] { "IdAtenciones" });
            DropTable("dbo.ExaMedicoAuditorias");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoPruebas");
            DropTable("dbo.ResultSers");
            DropTable("dbo.ResultMols");
            DropTable("dbo.ResultCuas");
            DropTable("dbo.ResultAgs");
            DropTable("dbo.DocIdes");
            DropTable("dbo.AtenciCovs");
            DropTable("dbo.Aptituds");
            DropTable("dbo.Medicinas");
            DropTable("dbo.Interconsultas");
            DropTable("dbo.Medicos");
            DropTable("dbo.ExaMedicoes");
            DropTable("dbo.Auditorias");
            DropTable("dbo.Atenciones");
            DropTable("dbo.Admisions");
        }
    }
}
