namespace work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restuarent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Quantity");
        }
    }
}
