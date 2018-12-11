namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Carts", new[] { "ClientId" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carts", "ClientId");
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "Id");
        }
    }
}
