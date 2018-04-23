namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hey1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Contacts_Email", "dbo.Contacts");
            DropIndex("dbo.People", new[] { "Contacts_Email" });
            AddColumn("dbo.People", "Contacts_Email1", c => c.String(maxLength: 128));
            CreateIndex("dbo.People", "Contacts_Email1");
            AddForeignKey("dbo.People", "Contacts_Email1", "dbo.Contacts", "Email");
            //DropColumn("dbo.People", "Contact_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            DropForeignKey("dbo.People", "Contacts_Email1", "dbo.Contacts");
            DropIndex("dbo.People", new[] { "Contacts_Email1" });
            DropColumn("dbo.People", "Contacts_Email1");
            CreateIndex("dbo.People", "Contacts_Email");
            AddForeignKey("dbo.People", "Contacts_Email", "dbo.Contacts", "Email");
        }
    }
}
