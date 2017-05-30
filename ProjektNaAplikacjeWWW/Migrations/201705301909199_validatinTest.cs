namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validatinTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
