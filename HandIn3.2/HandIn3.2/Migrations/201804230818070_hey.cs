namespace HandIn3._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hey : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.People", "Contact_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.People", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 128));
            //DropColumn("dbo.People", "Contact_Email");
        }
    }
}
