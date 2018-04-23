namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hey2 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.People", "Contacts_Email");
            //RenameColumn(table: "dbo.People", name: "Contacts_Email1", newName: "Contacts_Email");
            //RenameIndex(table: "dbo.People", name: "IX_Contacts_Email1", newName: "IX_Contacts_Email");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.People", name: "IX_Contacts_Email", newName: "IX_Contacts_Email1");
            RenameColumn(table: "dbo.People", name: "Contacts_Email", newName: "Contacts_Email1");
            AddColumn("dbo.People", "Contacts_Email", c => c.String(maxLength: 128));
        }
    }
}
