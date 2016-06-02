namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class orderid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.Ticket", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.Ticket", name: "Order_OrderId", newName: "OrderId");
            AlterColumn("dbo.Ticket", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "OrderId");
            AddForeignKey("dbo.Ticket", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "OrderId", "dbo.Order");
            DropIndex("dbo.Ticket", new[] { "OrderId" });
            AlterColumn("dbo.Ticket", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.Ticket", name: "OrderId", newName: "Order_OrderId");
            CreateIndex("dbo.Ticket", "Order_OrderId");
            AddForeignKey("dbo.Ticket", "Order_OrderId", "dbo.Order", "OrderId");
        }
    }
}
