namespace work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptsA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 40),
                        ItemPrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeId = c.Int(nullable: false, identity: true),
                        PaymentTypeName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.PaymentTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Items");
            DropTable("dbo.Customers");
        }
    }
}
