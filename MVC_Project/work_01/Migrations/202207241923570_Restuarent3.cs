namespace work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restuarent3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "ItemCategory_ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "ItemCategory_ItemCategoryId" });
            DropColumn("dbo.Items", "Category");
            RenameColumn(table: "dbo.Items", name: "ItemCategory_ItemCategoryId", newName: "Category");
            AlterColumn("dbo.Items", "Category", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "Category");
            AddForeignKey("dbo.Items", "Category", "dbo.ItemCategories", "ItemCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Category", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "Category" });
            AlterColumn("dbo.Items", "Category", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "Category", newName: "ItemCategory_ItemCategoryId");
            AddColumn("dbo.Items", "Category", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ItemCategory_ItemCategoryId");
            AddForeignKey("dbo.Items", "ItemCategory_ItemCategoryId", "dbo.ItemCategories", "ItemCategoryId");
        }
    }
}
