namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_espeMedic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EspecialidadMedicas",
                c => new
                    {
                        IdEspeMedic = c.Int(nullable: false, identity: true),
                        Especialidad = c.String(),
                    })
                .PrimaryKey(t => t.IdEspeMedic);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EspecialidadMedicas");
        }
    }
}
