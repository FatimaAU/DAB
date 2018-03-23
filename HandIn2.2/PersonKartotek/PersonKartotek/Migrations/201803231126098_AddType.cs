namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Type", c => c.String());
            AddColumn("dbo.Telephones", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telephones", "Type");
            DropColumn("dbo.Addresses", "Type");
        }
    }
}
