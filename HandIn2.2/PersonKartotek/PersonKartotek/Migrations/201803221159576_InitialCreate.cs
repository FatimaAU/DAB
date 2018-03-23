namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.AlternativeAddresses",
                c => new
                    {
                        AlternativeAddressId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AlternativeAddressId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.MainAddresses",
                c => new
                    {
                        MainAddressId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MainAddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .Index(t => t.Contact_ContactId);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        TelephoneId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TelephoneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.People", new[] { "Contact_ContactId" });
            DropTable("dbo.Telephones");
            DropTable("dbo.People");
            DropTable("dbo.MainAddresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.Cities");
            DropTable("dbo.AlternativeAddresses");
            DropTable("dbo.Addresses");
        }
    }
}
