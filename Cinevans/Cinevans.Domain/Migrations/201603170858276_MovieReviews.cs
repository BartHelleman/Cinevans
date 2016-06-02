namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "UserReview", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "UserReview");
        }
    }
}
