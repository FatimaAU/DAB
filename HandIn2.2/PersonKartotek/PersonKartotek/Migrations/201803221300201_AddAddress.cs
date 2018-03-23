namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlternativeAddresses", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.AlternativeAddresses", "Address_AddressId");
            AddForeignKey("dbo.AlternativeAddresses", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlternativeAddresses", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AlternativeAddresses", new[] { "Address_AddressId" });
            DropColumn("dbo.AlternativeAddresses", "Address_AddressId");
        }
    }
}
