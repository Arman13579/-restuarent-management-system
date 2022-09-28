namespace work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restuarent2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        ItemCategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ItemCategoryId);
            
            AddColumn("dbo.Items", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "ItemPicture", c => c.String());
            AddColumn("dbo.Items", "ItemCategory_ItemCategoryId", c => c.Int());
            CreateIndex("dbo.Items", "ItemCategory_ItemCategoryId");
            AddForeignKey("dbo.Items", "ItemCategory_ItemCategoryId", "dbo.ItemCategories", "ItemCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategory_ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "ItemCategory_ItemCategoryId" });
            DropColumn("dbo.Items", "ItemCategory_ItemCategoryId");
            DropColumn("dbo.Items", "ItemPicture");
            DropColumn("dbo.Items", "IsAvailable");
            DropColumn("dbo.Items", "Category");
            DropColumn("dbo.Items", "PurchaseDate");
            DropColumn("dbo.Items", "Quantity");
            DropTable("dbo.ItemCategories");
        }
    }
}
