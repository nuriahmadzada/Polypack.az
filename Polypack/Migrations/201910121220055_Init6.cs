namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Email", c => c.String(nullable: false, maxLength: 45));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Email", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
