namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStreetName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StreetName", c => c.String());
            AddColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "Country", c => c.String());
            AddColumn("dbo.Addresses", "City_CityId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Addresses", "City_CityId");
            AddForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            DropColumn("dbo.Addresses", "City_CityId");
            DropColumn("dbo.Addresses", "Country");
            DropColumn("dbo.Addresses", "HouseNumber");
            DropColumn("dbo.Addresses", "StreetName");
        }
    }
}
