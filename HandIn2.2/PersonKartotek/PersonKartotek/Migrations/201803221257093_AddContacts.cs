namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContacts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternativeAddresses", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.AlternativeAddresses", new[] { "Contact_ContactId" });
            CreateTable(
                "dbo.ContactAlternativeAddresses",
                c => new
                    {
                        Contact_ContactId = c.Int(nullable: false),
                        AlternativeAddress_AlternativeAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contact_ContactId, t.AlternativeAddress_AlternativeAddressId })
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AlternativeAddresses", t => t.AlternativeAddress_AlternativeAddressId, cascadeDelete: true)
                .Index(t => t.Contact_ContactId)
                .Index(t => t.AlternativeAddress_AlternativeAddressId);
            
            DropColumn("dbo.AlternativeAddresses", "Contact_ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlternativeAddresses", "Contact_ContactId", c => c.Int());
            DropForeignKey("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId", "dbo.AlternativeAddresses");
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "AlternativeAddress_AlternativeAddressId" });
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_ContactId" });
            DropTable("dbo.ContactAlternativeAddresses");
            CreateIndex("dbo.AlternativeAddresses", "Contact_ContactId");
            AddForeignKey("dbo.AlternativeAddresses", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
