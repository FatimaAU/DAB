namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contact_ContactId" });
            RenameColumn(table: "dbo.Telephones", name: "Contact_ContactId", newName: "ContactId");
            AlterColumn("dbo.Telephones", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Telephones", "ContactId");
            AddForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "ContactId" });
            AlterColumn("dbo.Telephones", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.Telephones", name: "ContactId", newName: "Contact_ContactId");
            CreateIndex("dbo.Telephones", "Contact_ContactId");
            AddForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}
