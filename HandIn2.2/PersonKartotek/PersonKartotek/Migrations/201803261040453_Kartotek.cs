namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kartotek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kartoteks",
                c => new
                    {
                        KartotekId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.KartotekId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kartoteks");
        }
    }
}
