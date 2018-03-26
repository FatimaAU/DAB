namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kartotek2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Kartotek_KartotekId", c => c.Int());
            CreateIndex("dbo.People", "Kartotek_KartotekId");
            AddForeignKey("dbo.People", "Kartotek_KartotekId", "dbo.Kartoteks", "KartotekId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Kartotek_KartotekId", "dbo.Kartoteks");
            DropIndex("dbo.People", new[] { "Kartotek_KartotekId" });
            DropColumn("dbo.People", "Kartotek_KartotekId");
        }
    }
}
