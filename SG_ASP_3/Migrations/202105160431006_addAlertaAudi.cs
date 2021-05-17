namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAlertaAudi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atenciones", "AleAud", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Atenciones", "AleAud");
        }
    }
}
