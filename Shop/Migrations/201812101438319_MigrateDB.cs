namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Orders", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductId", c => c.Int());
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Products", "Order_Id");
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id");
        }
    }
}
