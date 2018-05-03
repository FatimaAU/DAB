namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropIndex("dbo.AlternativeAddresses", new[] { "Contact_Email" });
            CreateTable(
                "dbo.ContactAlternativeAddresses",
                c => new
                    {
                        Contact_Email = c.String(nullable: false, maxLength: 128),
                        AlternativeAddress_AlternativeAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contact_Email, t.AlternativeAddress_AlternativeAddressId })
                .ForeignKey("dbo.Contacts", t => t.Contact_Email, cascadeDelete: true)
                .ForeignKey("dbo.AlternativeAddresses", t => t.AlternativeAddress_AlternativeAddressId, cascadeDelete: true)
                .Index(t => t.Contact_Email)
                .Index(t => t.AlternativeAddress_AlternativeAddressId);
            
            DropColumn("dbo.AlternativeAddresses", "Contact_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId", "dbo.AlternativeAddresses");
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "AlternativeAddress_AlternativeAddressId" });
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_Email" });
            DropTable("dbo.ContactAlternativeAddresses");
            CreateIndex("dbo.AlternativeAddresses", "Contact_Email");
            AddForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts", "Email");
        }
    }
}
