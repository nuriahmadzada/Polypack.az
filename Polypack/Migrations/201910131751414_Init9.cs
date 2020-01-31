namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Phone");
            DropColumn("dbo.Messages", "IsSeen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "IsSeen", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Phone", c => c.String(nullable: false, maxLength: 14));
        }
    }
}
