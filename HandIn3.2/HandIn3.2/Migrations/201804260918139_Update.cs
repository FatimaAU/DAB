namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Cities_CityId", "dbo.Cities");
            DropForeignKey("dbo.Contacts", "Telephones_TelephoneId", "dbo.Telephones");
            DropIndex("dbo.Addresses", new[] { "Cities_CityId" });
            DropIndex("dbo.Contacts", new[] { "Telephones_TelephoneId" });
            //RenameColumn(table: "dbo.Telephones", name: "Telephones_TelephoneId", newName: "Contacts_Email");
            //AddColumn("dbo.Addresses", "Cities_CityId1", c => c.Int());
            //AddColumn("dbo.AlternativeAddresses", "Address_AddressId", c => c.Int());
            //AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            //AddColumn("dbo.Contacts", "MainAddress_MainAddressId", c => c.Int());
            //AddColumn("dbo.MainAddresses", "Address_AddressId", c => c.Int());
            //AddColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            //AddColumn("dbo.Telephones", "Contact_Email", c => c.String(maxLength: 128));
            //CreateIndex("dbo.Addresses", "Cities_CityId1");
            //CreateIndex("dbo.Telephones", "Contacts_Email");
            //AddForeignKey("dbo.Addresses", "Cities_CityId1", "dbo.Cities", "CityId");
            //AddForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts", "Email", cascadeDelete: true);
            //DropColumn("dbo.Contacts", "Telephones_TelephoneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Telephones_TelephoneId", c => c.Int());
            DropForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "Cities_CityId1", "dbo.Cities");
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            DropIndex("dbo.Addresses", new[] { "Cities_CityId1" });
            DropColumn("dbo.Telephones", "Contact_Email");
            DropColumn("dbo.People", "Contact_Email");
            DropColumn("dbo.MainAddresses", "Address_AddressId");
            DropColumn("dbo.Contacts", "MainAddress_MainAddressId");
            DropColumn("dbo.AlternativeAddresses", "Contact_Email");
            DropColumn("dbo.AlternativeAddresses", "Address_AddressId");
            DropColumn("dbo.Addresses", "Cities_CityId1");
            RenameColumn(table: "dbo.Telephones", name: "Contacts_Email", newName: "Telephones_TelephoneId");
            CreateIndex("dbo.Contacts", "Telephones_TelephoneId");
            CreateIndex("dbo.Addresses", "Cities_CityId");
            AddForeignKey("dbo.Contacts", "Telephones_TelephoneId", "dbo.Telephones", "TelephoneId");
            AddForeignKey("dbo.Addresses", "Cities_CityId", "dbo.Cities", "CityId");
        }
    }
}
