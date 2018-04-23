namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItWorks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            
            RenameColumn(table: "dbo.Addresses", name: "Cities_CityId1", newName: "Cities_CityId");
            RenameIndex(table: "dbo.Addresses", name: "IX_Cities_CityId1", newName: "IX_Cities_CityId");
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 128));
            //DropColumn("dbo.AlternativeAddresses", "Address_AddressId");
            //DropColumn("dbo.AlternativeAddresses", "Contact_Email");
            //DropColumn("dbo.Contacts", "MainAddress_MainAddressId");
            //DropColumn("dbo.MainAddresses", "Address_AddressId");
            //DropColumn("dbo.People", "Contact_Email");
            //DropColumn("dbo.Telephones", "Contact_Email");
            //DropColumn("dbo.Telephones", "Contacts_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Telephones", "Contacts_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.Telephones", "Contact_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.MainAddresses", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Contacts", "MainAddress_MainAddressId", c => c.Int());
            AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.AlternativeAddresses", "Address_AddressId", c => c.Int());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            RenameIndex(table: "dbo.Addresses", name: "IX_Cities_CityId", newName: "IX_Cities_CityId1");
            RenameColumn(table: "dbo.Addresses", name: "Cities_CityId", newName: "Cities_CityId1");
            AddColumn("dbo.Addresses", "Cities_CityId", c => c.Int());
            CreateIndex("dbo.Telephones", "Contacts_Email");
            AddForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts", "Email");
        }
    }
}
