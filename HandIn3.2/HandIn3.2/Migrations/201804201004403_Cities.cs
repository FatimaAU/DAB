namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Cities_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "Cities_CityId" });
            AddColumn("dbo.Addresses", "Cities_CityId1", c => c.Int());
            CreateIndex("dbo.Addresses", "Cities_CityId1");
            AddForeignKey("dbo.Addresses", "Cities_CityId1", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "City_CityId", c => c.Int());
            DropForeignKey("dbo.Addresses", "Cities_CityId1", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "Cities_CityId1" });
            DropColumn("dbo.Addresses", "Cities_CityId1");
            CreateIndex("dbo.Addresses", "Cities_CityId");
            AddForeignKey("dbo.Addresses", "Cities_CityId", "dbo.Cities", "CityId");
        }
    }
}
