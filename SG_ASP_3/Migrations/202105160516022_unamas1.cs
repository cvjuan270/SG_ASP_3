namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unamas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atenciones", "AleEnf", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Atenciones", "AleEnf");
        }
    }
}
