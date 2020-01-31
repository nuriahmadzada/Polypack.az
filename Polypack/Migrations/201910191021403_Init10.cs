namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SubCategory_Id", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategory_Id" });
            RenameColumn(table: "dbo.Products", name: "SubCategory_Id", newName: "SubCategoryId");
            AlterColumn("dbo.Products", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            AlterColumn("dbo.Products", "SubCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "SubCategoryId", newName: "SubCategory_Id");
            CreateIndex("dbo.Products", "SubCategory_Id");
            AddForeignKey("dbo.Products", "SubCategory_Id", "dbo.SubCategories", "Id");
        }
    }
}
