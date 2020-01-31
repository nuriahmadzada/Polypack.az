namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SubCategory_Id", c => c.Int());
            DropForeignKey("dbo.SubCategoryProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SubCategoryProducts", "SubCategory_Id", "dbo.SubCategories");
            DropIndex("dbo.SubCategoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.SubCategoryProducts", new[] { "SubCategory_Id" });
            DropTable("dbo.SubCategoryProducts");
            CreateIndex("dbo.Products", "SubCategory_Id");
            AddForeignKey("dbo.Products", "SubCategory_Id", "dbo.SubCategories", "Id");
        }
    }
}
