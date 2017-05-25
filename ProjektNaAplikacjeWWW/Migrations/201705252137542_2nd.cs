namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "UserID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "UserID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.User", "UserID");
        }
    }
}
