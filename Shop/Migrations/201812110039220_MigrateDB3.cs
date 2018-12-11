namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "ProductId", "dbo.Products");
            DropIndex("dbo.Applications", new[] { "ProductId" });
            AddColumn("dbo.Products", "Application_Id", c => c.Int());
            CreateIndex("dbo.Products", "Application_Id");
            AddForeignKey("dbo.Products", "Application_Id", "dbo.Applications", "Id");
            DropColumn("dbo.Applications", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "ProductId", c => c.Int());
            DropForeignKey("dbo.Products", "Application_Id", "dbo.Applications");
            DropIndex("dbo.Products", new[] { "Application_Id" });
            DropColumn("dbo.Products", "Application_Id");
            CreateIndex("dbo.Applications", "ProductId");
            AddForeignKey("dbo.Applications", "ProductId", "dbo.Products", "Id");
        }
    }
}
