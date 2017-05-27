namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogId = c.Guid(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        log = c.String(),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
