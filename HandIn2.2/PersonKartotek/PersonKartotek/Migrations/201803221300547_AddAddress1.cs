namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainAddresses", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.MainAddresses", "Address_AddressId");
            AddForeignKey("dbo.MainAddresses", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainAddresses", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.MainAddresses", new[] { "Address_AddressId" });
            DropColumn("dbo.MainAddresses", "Address_AddressId");
        }
    }
}
