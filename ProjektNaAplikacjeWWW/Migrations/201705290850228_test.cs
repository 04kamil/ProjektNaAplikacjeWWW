namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "URL", c => c.String());
            DropColumn("dbo.Book", "ImgURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "ImgURL", c => c.String());
            DropColumn("dbo.Book", "URL");
        }
    }
}
