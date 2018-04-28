namespace Handin3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
        //    DropForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts");
        //    DropIndex("dbo.AlternativeAddresses", new[] { "Contact_Email" });
        //    CreateTable(
        //        "dbo.ContactAlternativeAddresses",
        //        c => new
        //            {
        //                AlternativeAddress_AlternativeAddressId = c.Int(nullable: false),
        //                Contact_Email = c.String(nullable: false, maxLength: 128),
        //            })
        //        .PrimaryKey(t => new { t.AlternativeAddress_AlternativeAddressId, t.Contact_Email })
        //        .ForeignKey("dbo.AlternativeAddresses", t => t.AlternativeAddress_AlternativeAddressId, cascadeDelete: true)
        //        .ForeignKey("dbo.Contacts", t => t.Contact_Email, cascadeDelete: true)
        //        .Index(t => t.AlternativeAddress_AlternativeAddressId)
        //        .Index(t => t.Contact_Email);
            
        //    DropColumn("dbo.AlternativeAddresses", "Contact_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlternativeAddresses", "Contact_Email", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ContactAlternativeAddresses", "Contact_Email", "dbo.Contacts");
            DropForeignKey("dbo.ContactAlternativeAddresses", "AlternativeAddress_AlternativeAddressId", "dbo.AlternativeAddresses");
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "Contact_Email" });
            DropIndex("dbo.ContactAlternativeAddresses", new[] { "AlternativeAddress_AlternativeAddressId" });
            DropTable("dbo.ContactAlternativeAddresses");
            CreateIndex("dbo.AlternativeAddresses", "Contact_Email");
            AddForeignKey("dbo.AlternativeAddresses", "Contact_Email", "dbo.Contacts", "Email");
        }
    }
}
