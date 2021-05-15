namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actua : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuditoriaExaMedicoes", newName: "ExaMedicoAuditorias");
            DropPrimaryKey("dbo.ExaMedicoAuditorias");
            AddPrimaryKey("dbo.ExaMedicoAuditorias", new[] { "ExaMedico_IdExMed", "Auditoria_IdAudi" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ExaMedicoAuditorias");
            AddPrimaryKey("dbo.ExaMedicoAuditorias", new[] { "Auditoria_IdAudi", "ExaMedico_IdExMed" });
            RenameTable(name: "dbo.ExaMedicoAuditorias", newName: "AuditoriaExaMedicoes");
        }
    }
}
