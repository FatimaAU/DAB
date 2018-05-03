namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleDTO : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            AlterColumn("dbo.Telephones", "Contacts_Email", c => c.String(nullable: true, maxLength: 128));
            CreateIndex("dbo.Telephones", "Contacts_Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Telephones", new[] { "Contacts_Email" });
            AlterColumn("dbo.Telephones", "Contacts_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Telephones", "Contacts_Email");
        }
    }
}
