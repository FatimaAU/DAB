namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTelephones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlternativeAddresses", "Contact_ContactId", c => c.Int());
            AddColumn("dbo.Contacts", "MainAddress_MainAddressId", c => c.Int());
            AddColumn("dbo.Telephones", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.AlternativeAddresses", "Contact_ContactId");
            CreateIndex("dbo.Contacts", "MainAddress_MainAddressId");
            CreateIndex("dbo.Telephones", "Contact_ContactId");
            AddForeignKey("dbo.AlternativeAddresses", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.Contacts", "MainAddress_MainAddressId", "dbo.MainAddresses", "MainAddressId");
            AddForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "MainAddress_MainAddressId", "dbo.MainAddresses");
            DropForeignKey("dbo.AlternativeAddresses", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contact_ContactId" });
            DropIndex("dbo.Contacts", new[] { "MainAddress_MainAddressId" });
            DropIndex("dbo.AlternativeAddresses", new[] { "Contact_ContactId" });
            DropColumn("dbo.Telephones", "Contact_ContactId");
            DropColumn("dbo.Contacts", "MainAddress_MainAddressId");
            DropColumn("dbo.AlternativeAddresses", "Contact_ContactId");
        }
    }
}
