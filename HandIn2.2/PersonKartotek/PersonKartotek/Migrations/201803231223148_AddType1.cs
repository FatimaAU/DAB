namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddType1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            RenameColumn(table: "dbo.Addresses", name: "City_CityId", newName: "City_CityName");
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Addresses", "City_CityName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cities", "CityName");
            CreateIndex("dbo.Addresses", "City_CityName");
            AddForeignKey("dbo.Addresses", "City_CityName", "dbo.Cities", "CityName");
            DropColumn("dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "CityId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Addresses", "City_CityName", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "City_CityName" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "CityName", c => c.String());
            AlterColumn("dbo.Addresses", "City_CityName", c => c.Int());
            AddPrimaryKey("dbo.Cities", "CityId");
            RenameColumn(table: "dbo.Addresses", name: "City_CityName", newName: "City_CityId");
            CreateIndex("dbo.Addresses", "City_CityId");
            AddForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities", "CityId");
        }
    }
}
