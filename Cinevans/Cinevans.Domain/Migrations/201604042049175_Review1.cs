namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Review", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Review", "UserName", c => c.Int(nullable: false));
        }
    }
}
