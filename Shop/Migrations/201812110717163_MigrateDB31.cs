namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Carts", new[] { "ClientId" });
            DropTable("dbo.Carts");
        }
    }
}
