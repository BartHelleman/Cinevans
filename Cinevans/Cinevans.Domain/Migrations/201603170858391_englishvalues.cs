namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;
    [ExcludeFromCodeCoverage]
    public partial class englishvalues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "EnglishDescription", c => c.String());
            AddColumn("dbo.Rate", "EnglishName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rate", "EnglishName");
            DropColumn("dbo.Movie", "EnglishDescription");
        }
    }
}
