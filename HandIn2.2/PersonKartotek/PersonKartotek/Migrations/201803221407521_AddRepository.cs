namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRepository : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Telephones", "Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telephones", "Number", c => c.Int(nullable: false));
        }
    }
}
