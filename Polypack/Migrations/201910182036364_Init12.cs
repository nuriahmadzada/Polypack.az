namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SubCategory_Id", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategory_Id" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropColumn("dbo.Categories", "Photo");
            DropColumn("dbo.Products", "SubCategory_Id");
            DropTable("dbo.SubCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "SubCategory_Id", c => c.Int());
            AddColumn("dbo.Categories", "Photo", c => c.String());
            CreateIndex("dbo.SubCategories", "CategoryId");
            CreateIndex("dbo.Products", "SubCategory_Id");
            AddForeignKey("dbo.Products", "SubCategory_Id", "dbo.SubCategories", "Id");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
