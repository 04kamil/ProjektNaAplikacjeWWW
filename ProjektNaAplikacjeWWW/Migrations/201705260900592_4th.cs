namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registration",
                c => new
                    {
                        RegistrationID = c.Guid(nullable: false, identity: true),
                        EmailSend = c.DateTime(nullable: false),
                        EmailExpired = c.DateTime(nullable: false),
                        ConfirmRegistrationCode = c.String(),
                        Uzk_UserID = c.Guid(),
                    })
                .PrimaryKey(t => t.RegistrationID)
                .ForeignKey("dbo.User", t => t.Uzk_UserID)
                .Index(t => t.Uzk_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registration", "Uzk_UserID", "dbo.User");
            DropIndex("dbo.Registration", new[] { "Uzk_UserID" });
            DropTable("dbo.Registration");
        }
    }
}
