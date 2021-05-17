namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alernullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Atenciones", "AleMed", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Atenciones", "AleMed", c => c.Int(nullable: false));
        }
    }
}
