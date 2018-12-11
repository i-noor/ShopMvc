namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        ProductId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(),
                        ProductId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        ProductId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Applications", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Applications", "ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Applications", new[] { "ProductId" });
            DropIndex("dbo.Applications", new[] { "ClientId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Employees");
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
            DropTable("dbo.Applications");
        }
    }
}
