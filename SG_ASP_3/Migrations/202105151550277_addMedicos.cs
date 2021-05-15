namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        IdMedico = c.Int(nullable: false, identity: true),
                        NomApe = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdMedico);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicos");
        }
    }
}
