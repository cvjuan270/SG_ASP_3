namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unamas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atenciones", "AleMed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Atenciones", "AleMed");
        }
    }
}
