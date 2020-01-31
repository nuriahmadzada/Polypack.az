namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İnit7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Photo", c => c.String());
            AddColumn("dbo.Contacts", "Desc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Desc");
            DropColumn("dbo.Contacts", "Photo");
        }
    }
}
