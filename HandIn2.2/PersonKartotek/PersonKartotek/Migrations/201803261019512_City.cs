namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "City_ZipCode", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_ZipCode" });
            RenameColumn(table: "dbo.Addresses", name: "City_ZipCode", newName: "City_CityId");
            DropPrimaryKey("dbo.Cities");
            AddColumn("dbo.Cities", "CityId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Addresses", "City_CityId", c => c.Int());
            AlterColumn("dbo.Cities", "ZipCode", c => c.String());
            AddPrimaryKey("dbo.Cities", "CityId");
            CreateIndex("dbo.Addresses", "City_CityId");
            AddForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "ZipCode", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Addresses", "City_CityId", c => c.String(maxLength: 128));
            DropColumn("dbo.Cities", "CityId");
            AddPrimaryKey("dbo.Cities", "ZipCode");
            RenameColumn(table: "dbo.Addresses", name: "City_CityId", newName: "City_ZipCode");
            CreateIndex("dbo.Addresses", "City_ZipCode");
            AddForeignKey("dbo.Addresses", "City_ZipCode", "dbo.Cities", "ZipCode");
        }
    }
}
