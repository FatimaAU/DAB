namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Program : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropForeignKey("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId", "dbo.AlternativeAddresses");
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_Email" });
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "AlternativeAddress_AlternativeAddressId" });
            AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.AlternativeAddresses", "Contact_Email");
            AddForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts", "Email");
            DropTable("dbo.ContactAlternativeAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactAlternativeAddresses",
                c => new
                    {
                        Contact_Email = c.String(nullable: false, maxLength: 128),
                        AlternativeAddress_AlternativeAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contact_Email, t.AlternativeAddress_AlternativeAddressId });
            
            DropForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropIndex("dbo.AlternativeAddresses", new[] { "Contact_Email" });
            DropColumn("dbo.AlternativeAddresses", "Contact_Email");
            CreateIndex("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId");
            CreateIndex("dbo.ContactAlternativeAddresses", "Contact_Email");
            AddForeignKey("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId", "dbo.AlternativeAddresses", "AlternativeAddressId", cascadeDelete: true);
            AddForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts", "Email", cascadeDelete: true);
        }
    }
}
