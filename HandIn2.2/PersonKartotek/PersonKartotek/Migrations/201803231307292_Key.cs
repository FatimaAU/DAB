namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "City_CityName", "dbo.Cities");
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.People", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contact_ContactId" });
            DropIndex("dbo.People", new[] { "Contact_ContactId" });
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_ContactId" });
            RenameColumn(table: "dbo.Addresses", name: "City_CityName", newName: "City_ZipCode");
            RenameColumn(table: "dbo.ContactAlternativeAddresses", name: "Contact_ContactId", newName: "Contact_Email");
            RenameColumn(table: "dbo.Telephones", name: "Contact_ContactId", newName: "Contact_Email");
            RenameColumn(table: "dbo.People", name: "Contact_ContactId", newName: "Contact_Email");
            RenameIndex(table: "dbo.Addresses", name: "IX_City_CityName", newName: "IX_City_ZipCode");
            DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.Contacts");
            DropPrimaryKey("dbo.Telephones");
            DropPrimaryKey("dbo.ContactAlternativeAddresses");
            AlterColumn("dbo.Cities", "CityName", c => c.String());
            AlterColumn("dbo.Cities", "ZipCode", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Telephones", "Number", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Telephones", "Contact_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.ContactAlternativeAddresses", "Contact_Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cities", "ZipCode");
            AddPrimaryKey("dbo.Contacts", "Email");
            AddPrimaryKey("dbo.Telephones", "Number");
            AddPrimaryKey("dbo.ContactAlternativeAddresses", new[] { "Contact_Email", "AlternativeAddress_AlternativeAddressId" });
            CreateIndex("dbo.Telephones", "Contact_Email");
            CreateIndex("dbo.People", "Contact_Email");
            CreateIndex("dbo.ContactAlternativeAddresses", "Contact_Email");
            AddForeignKey("dbo.Addresses", "City_ZipCode", "dbo.Cities", "ZipCode");
            AddForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts", "Email", cascadeDelete: true);
            AddForeignKey("dbo.Telephones", "Contact_Email", "dbo.Contacts", "Email");
            AddForeignKey("dbo.People", "Contact_Email", "dbo.Contacts", "Email");
            DropColumn("dbo.Contacts", "ContactId");
            DropColumn("dbo.Telephones", "TelephoneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Telephones", "TelephoneId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Contacts", "ContactId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.People", "Contact_Email", "dbo.Contacts");
            DropForeignKey("dbo.Telephones", "Contact_Email", "dbo.Contacts");
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "City_ZipCode", "dbo.Cities");
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_Email" });
            DropIndex("dbo.People", new[] { "Contact_Email" });
            DropIndex("dbo.Telephones", new[] { "Contact_Email" });
            DropPrimaryKey("dbo.ContactAlternativeAddresses");
            DropPrimaryKey("dbo.Telephones");
            DropPrimaryKey("dbo.Contacts");
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.ContactAlternativeAddresses", "Contact_Email", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "Contact_Email", c => c.Int());
            AlterColumn("dbo.Telephones", "Contact_Email", c => c.Int());
            AlterColumn("dbo.Telephones", "Number", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Cities", "ZipCode", c => c.String());
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ContactAlternativeAddresses", new[] { "Contact_ContactId", "AlternativeAddress_AlternativeAddressId" });
            AddPrimaryKey("dbo.Telephones", "TelephoneId");
            AddPrimaryKey("dbo.Contacts", "ContactId");
            AddPrimaryKey("dbo.Cities", "CityName");
            RenameIndex(table: "dbo.Addresses", name: "IX_City_ZipCode", newName: "IX_City_CityName");
            RenameColumn(table: "dbo.People", name: "Contact_Email", newName: "Contact_ContactId");
            RenameColumn(table: "dbo.Telephones", name: "Contact_Email", newName: "Contact_ContactId");
            RenameColumn(table: "dbo.ContactAlternativeAddresses", name: "Contact_Email", newName: "Contact_ContactId");
            RenameColumn(table: "dbo.Addresses", name: "City_ZipCode", newName: "City_CityName");
            CreateIndex("dbo.ContactAlternativeAddresses", "Contact_ContactId");
            CreateIndex("dbo.People", "Contact_ContactId");
            CreateIndex("dbo.Telephones", "Contact_ContactId");
            AddForeignKey("dbo.People", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.ContactAlternativeAddresses", "Contact_ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "City_CityName", "dbo.Cities", "CityName");
        }
    }
}
