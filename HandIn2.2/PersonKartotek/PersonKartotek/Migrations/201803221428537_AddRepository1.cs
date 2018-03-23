namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRepository1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "ContactId" });
            RenameColumn(table: "dbo.Telephones", name: "ContactId", newName: "Contact_ContactId");
            AlterColumn("dbo.Telephones", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Telephones", "Contact_ContactId");
            AddForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "Contact_ContactId" });
            AlterColumn("dbo.Telephones", "Contact_ContactId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Telephones", name: "Contact_ContactId", newName: "ContactId");
            CreateIndex("dbo.Telephones", "ContactId");
            AddForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
    }
}
