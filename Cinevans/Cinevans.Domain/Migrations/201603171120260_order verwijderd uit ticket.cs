namespace Cinevans.Domain.Migrations {
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class orderverwijderduitticket:DbMigration {
        public override void Up() {
            DropForeignKey("dbo.Ticket", "OrderId", "dbo.Order");
            DropIndex("dbo.Ticket", new[] { "OrderId" });
            RenameColumn(table: "dbo.Ticket", name: "OrderId", newName: "Order_OrderId");
            AddColumn("dbo.Ticket", "OrderNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Ticket", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Ticket", "Order_OrderId");
            AddForeignKey("dbo.Ticket", "Order_OrderId", "dbo.Order", "OrderId");
        }

        public override void Down() {
            DropForeignKey("dbo.Ticket", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.Ticket", new[] { "Order_OrderId" });
            AlterColumn("dbo.Ticket", "Order_OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.Ticket", "OrderNumber");
            RenameColumn(table: "dbo.Ticket", name: "Order_OrderId", newName: "OrderId");
            CreateIndex("dbo.Ticket", "OrderId");
            AddForeignKey("dbo.Ticket", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
        }
    }
}
