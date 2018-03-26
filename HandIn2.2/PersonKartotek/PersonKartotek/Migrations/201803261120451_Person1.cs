namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Kartotek_KartotekId", "dbo.Kartoteks");
            DropIndex("dbo.People", new[] { "Kartotek_KartotekId" });
            DropColumn("dbo.People", "Kartotek_KartotekId");
            DropTable("dbo.Kartoteks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Kartoteks",
                c => new
                    {
                        KartotekId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.KartotekId);
            
            AddColumn("dbo.People", "Kartotek_KartotekId", c => c.Int());
            CreateIndex("dbo.People", "Kartotek_KartotekId");
            AddForeignKey("dbo.People", "Kartotek_KartotekId", "dbo.Kartoteks", "KartotekId");
        }
    }
}
