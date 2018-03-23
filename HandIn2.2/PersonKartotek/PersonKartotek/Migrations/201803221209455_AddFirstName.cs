namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "FirstName", c => c.String());
            AddColumn("dbo.People", "MiddleName", c => c.String());
            AddColumn("dbo.People", "LastName", c => c.String());
            DropColumn("dbo.People", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Name", c => c.String());
            DropColumn("dbo.People", "LastName");
            DropColumn("dbo.People", "MiddleName");
            DropColumn("dbo.People", "FirstName");
        }
    }
}
