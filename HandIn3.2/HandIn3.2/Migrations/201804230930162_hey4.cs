namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hey4 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.AlternativeAddresses", "Address_AddressId", c => c.Int());
            //AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            //AddColumn("dbo.MainAddresses", "Address_AddressId", c => c.Int());
            //AddColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            //AddColumn("dbo.Telephones", "Contact_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.Telephones", "Contacts_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Telephones", "Contacts_Email");
            AddForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "Contacts_Email", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            DropColumn("dbo.Telephones", "Contacts_Email");
            DropColumn("dbo.Telephones", "Contact_Email");
            DropColumn("dbo.People", "Contact_Email");
            DropColumn("dbo.MainAddresses", "Address_AddressId");
            DropColumn("dbo.AlternativeAddresses", "Contact_Email");
            DropColumn("dbo.AlternativeAddresses", "Address_AddressId");
        }
    }
}
