namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnvHC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnvioHCs",
                c => new
                    {
                        IdEnvioHC = c.Int(nullable: false, identity: true),
                        IdAtenciones = c.Int(nullable: false),
                        FecEnv = c.DateTime(nullable: false),
                        Observ = c.String(),
                        contro = c.String(),
                    })
                .PrimaryKey(t => t.IdEnvioHC)
                .ForeignKey("dbo.Atenciones", t => t.IdAtenciones, cascadeDelete: true)
                .Index(t => t.IdAtenciones);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnvioHCs", "IdAtenciones", "dbo.Atenciones");
            DropIndex("dbo.EnvioHCs", new[] { "IdAtenciones" });
            DropTable("dbo.EnvioHCs");
        }
    }
}
