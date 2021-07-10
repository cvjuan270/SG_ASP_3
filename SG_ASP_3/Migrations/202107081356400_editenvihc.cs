namespace SG_ASP_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editenvihc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnvioHCs", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnvioHCs", "UserName");
        }
    }
}
