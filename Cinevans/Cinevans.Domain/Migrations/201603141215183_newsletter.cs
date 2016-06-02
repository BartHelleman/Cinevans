namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class newsletter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsLetter",
                c => new
                    {
                        NewsLetterId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.NewsLetterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsLetter");
        }
    }
}
