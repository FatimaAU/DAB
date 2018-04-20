namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {  }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Cities_CityId", "dbo.Cities");
            DropForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts");
            DropForeignKey("dbo.People", "Contacts_Email", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "MainAddresses_MainAddressId", "dbo.MainAddresses");
            DropForeignKey("dbo.MainAddresses", "Addresses_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AlternativeAddresses", "Contacts_Email", "dbo.Contacts");
            DropForeignKey("dbo.AlternativeAddresses", "Addresses_AddressId", "dbo.Addresses");
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            DropIndex("dbo.People", new[] { "Contacts_Email" });
            DropIndex("dbo.MainAddresses", new[] { "Addresses_AddressId" });
            DropIndex("dbo.Contacts", new[] { "MainAddresses_MainAddressId" });
            DropIndex("dbo.AlternativeAddresses", new[] { "Contacts_Email" });
            DropIndex("dbo.AlternativeAddresses", new[] { "Addresses_AddressId" });
            DropIndex("dbo.Addresses", new[] { "Cities_CityId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Telephones");
            DropTable("dbo.People");
            DropTable("dbo.MainAddresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.AlternativeAddresses");
            DropTable("dbo.Addresses");
        }
    }
}
