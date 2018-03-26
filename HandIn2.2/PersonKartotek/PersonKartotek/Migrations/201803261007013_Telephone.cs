namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Telephone : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Telephones");
            AddColumn("dbo.Telephones", "TelephoneId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Telephones", "Number", c => c.String());
            AddPrimaryKey("dbo.Telephones", "TelephoneId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Telephones");
            AlterColumn("dbo.Telephones", "Number", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Telephones", "TelephoneId");
            AddPrimaryKey("dbo.Telephones", "Number");
        }
    }
}
