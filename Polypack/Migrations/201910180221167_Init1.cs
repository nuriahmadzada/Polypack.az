namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoryProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SubCategoryProducts", "SubCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.SubCategoryProducts", new[] { "SubCategory_Id" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.SubCategoryProducts");
            DropTable("dbo.WeProvides");
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Partners");
            DropTable("dbo.Messages");
            DropTable("dbo.Headers");
            DropTable("dbo.Contacts");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Banners");
            DropTable("dbo.Abouts");
        }
    }
}
