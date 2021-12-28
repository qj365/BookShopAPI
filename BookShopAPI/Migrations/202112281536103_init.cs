namespace BookShopAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Photo = c.String(maxLength: 500),
                        Description = c.String(),
                        IdPublisher = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        IdAuthor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.IdCategory, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.IdPublisher, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.IdAuthor, cascadeDelete: true)
                .Index(t => t.IdPublisher)
                .Index(t => t.IdCategory)
                .Index(t => t.IdAuthor);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailOrder",
                c => new
                    {
                        IdOrder = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                        Amount = c.Int(),
                        Price = c.Int(),
                        TotalPrice = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdOrder, t.IdBook })
                .ForeignKey("dbo.Orders", t => t.IdOrder, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.IdBook, cascadeDelete: true)
                .Index(t => t.IdOrder)
                .Index(t => t.IdBook);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 100),
                        OrderDate = c.DateTime(),
                        ReceiveDate = c.DateTime(),
                        Note = c.String(),
                        PaymentMethod = c.String(maxLength: 4),
                        IdVoucher = c.Int(),
                        IdState = c.Int(),
                        IdCustomer = c.Int(),
                        IdInformation = c.Int(),
                        TotalPrice = c.Int(),
                        Reason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.IdInformation)
                .ForeignKey("dbo.Customer", t => t.IdCustomer)
                .ForeignKey("dbo.State", t => t.IdState)
                .ForeignKey("dbo.Voucher", t => t.IdVoucher)
                .Index(t => t.IdVoucher)
                .Index(t => t.IdState)
                .Index(t => t.IdCustomer)
                .Index(t => t.IdInformation);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 500),
                        Name = c.String(maxLength: 50),
                        Sdt = c.String(maxLength: 10),
                        Email = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Sdt = c.String(maxLength: 10),
                        Defaults = c.Boolean(),
                        IdCustomer = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.IdCustomer)
                .Index(t => t.IdCustomer);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discount = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Website = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "IdAuthor", "dbo.Author");
            DropForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.DetailOrder", "IdBook", "dbo.Book");
            DropForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Orders", "IdState", "dbo.State");
            DropForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.Information", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.Orders", "IdInformation", "dbo.Information");
            DropForeignKey("dbo.Book", "IdCategory", "dbo.Category");
            DropIndex("dbo.Information", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdInformation" });
            DropIndex("dbo.Orders", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdState" });
            DropIndex("dbo.Orders", new[] { "IdVoucher" });
            DropIndex("dbo.DetailOrder", new[] { "IdBook" });
            DropIndex("dbo.DetailOrder", new[] { "IdOrder" });
            DropIndex("dbo.Book", new[] { "IdAuthor" });
            DropIndex("dbo.Book", new[] { "IdCategory" });
            DropIndex("dbo.Book", new[] { "IdPublisher" });
            DropTable("dbo.Publisher");
            DropTable("dbo.Voucher");
            DropTable("dbo.State");
            DropTable("dbo.Information");
            DropTable("dbo.Customer");
            DropTable("dbo.Orders");
            DropTable("dbo.DetailOrder");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
