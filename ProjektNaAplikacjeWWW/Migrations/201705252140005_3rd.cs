namespace ProjektNaAplikacjeWWW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        Descryption = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Guid(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Lang = c.String(),
                        Pages = c.Int(nullable: false),
                        ISBN = c.String(),
                        Descryption = c.String(),
                        ImgURL = c.String(),
                        BookAuthor_AuthorID = c.Guid(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Author", t => t.BookAuthor_AuthorID)
                .Index(t => t.BookAuthor_AuthorID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Guid(nullable: false, identity: true),
                        DateOfSale = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Buyer_UserID = c.Guid(),
                        Product_BookId = c.Guid(),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.User", t => t.Buyer_UserID)
                .ForeignKey("dbo.Book", t => t.Product_BookId)
                .Index(t => t.Buyer_UserID)
                .Index(t => t.Product_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "Product_BookId", "dbo.Book");
            DropForeignKey("dbo.Sale", "Buyer_UserID", "dbo.User");
            DropForeignKey("dbo.Book", "BookAuthor_AuthorID", "dbo.Author");
            DropIndex("dbo.Sale", new[] { "Product_BookId" });
            DropIndex("dbo.Sale", new[] { "Buyer_UserID" });
            DropIndex("dbo.Book", new[] { "BookAuthor_AuthorID" });
            DropTable("dbo.Sale");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
