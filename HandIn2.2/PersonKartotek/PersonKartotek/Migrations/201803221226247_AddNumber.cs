namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Telephones", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Telephones", "TeleCompany", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telephones", "TeleCompany");
            DropColumn("dbo.Telephones", "Number");
        }
    }
}
