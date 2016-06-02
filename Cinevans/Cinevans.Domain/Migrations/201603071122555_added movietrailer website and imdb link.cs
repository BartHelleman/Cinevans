namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using System.Diagnostics.CodeAnalysis;
    [ExcludeFromCodeCoverage]
    public partial class addedmovietrailerwebsiteandimdblink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "MovieTrailerUrl", c => c.String());
            AddColumn("dbo.Movie", "MovieWebsite", c => c.String());
            AddColumn("dbo.Movie", "ImdbLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "ImdbLink");
            DropColumn("dbo.Movie", "MovieWebsite");
            DropColumn("dbo.Movie", "MovieTrailerUrl");
        }
    }
}
