namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        Country = c.String(),
                        City_CityId = c.Int(),
                        Type = c.String(),
                        Cities_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Cities", t => t.Cities_CityId)
                .Index(t => t.Cities_CityId);
            
            CreateTable(
                "dbo.AlternativeAddresses",
                c => new
                    {
                        AlternativeAddressId = c.Int(nullable: false, identity: true),
                        Address_AddressId = c.Int(),
                        Contact_Email = c.String(maxLength: 128),
                        Addresses_AddressId = c.Int(),
                        Contacts_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AlternativeAddressId)
                .ForeignKey("dbo.Addresses", t => t.Addresses_AddressId)
                .ForeignKey("dbo.Contacts", t => t.Contacts_Email)
                .Index(t => t.Addresses_AddressId)
                .Index(t => t.Contacts_Email);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        MainAddress_MainAddressId = c.Int(),
                        MainAddresses_MainAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.MainAddresses", t => t.MainAddresses_MainAddressId)
                .Index(t => t.MainAddresses_MainAddressId);
            
            CreateTable(
                "dbo.MainAddresses",
                c => new
                    {
                        MainAddressId = c.Int(nullable: false, identity: true),
                        Address_AddressId = c.Int(),
                        Addresses_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.MainAddressId)
                .ForeignKey("dbo.Addresses", t => t.Addresses_AddressId)
                .Index(t => t.Addresses_AddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Contact_Email = c.String(maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Contacts_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Contacts", t => t.Contacts_Email)
                .Index(t => t.Contacts_Email);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        TelephoneId = c.Int(nullable: false, identity: true),
                        Contact_Email = c.String(maxLength: 128),
                        Number = c.String(),
                        TeleCompany = c.String(),
                        Type = c.String(),
                        Contacts_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TelephoneId)
                .ForeignKey("dbo.Contacts", t => t.Contacts_Email)
                .Index(t => t.Contacts_Email);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
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
