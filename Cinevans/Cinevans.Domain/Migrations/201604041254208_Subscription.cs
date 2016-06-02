namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Image = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscription");
        }
    }
}
