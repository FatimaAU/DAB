namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            DropPrimaryKey("dbo.Cities");
            AddColumn("dbo.Cities", "CityName", c => c.String());
            AddColumn("dbo.Cities", "ZipCode", c => c.String());
            AlterColumn("dbo.Addresses", "City_CityId", c => c.Int());
            AlterColumn("dbo.Cities", "CityId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cities", "CityId");
            CreateIndex("dbo.Addresses", "City_CityId");
            AddForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "CityId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Addresses", "City_CityId", c => c.String(maxLength: 128));
            DropColumn("dbo.Cities", "ZipCode");
            DropColumn("dbo.Cities", "CityName");
            AddPrimaryKey("dbo.Cities", "CityId");
            CreateIndex("dbo.Addresses", "City_CityId");
            AddForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities", "CityId");
        }
    }
}
