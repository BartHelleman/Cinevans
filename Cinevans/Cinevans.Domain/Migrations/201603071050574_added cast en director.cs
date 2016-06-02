namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using System.Diagnostics.CodeAnalysis;
    [ExcludeFromCodeCoverage]
    public partial class addedcastendirector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cast",
                c => new
                    {
                        CastId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CastId);
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.MovieCast",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CastId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CastId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Cast", t => t.CastId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CastId);
            
            CreateTable(
                "dbo.MovieDirector",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.DirectorId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Director", t => t.DirectorId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.DirectorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieDirector", "DirectorId", "dbo.Director");
            DropForeignKey("dbo.MovieDirector", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCast", "CastId", "dbo.Cast");
            DropForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie");
            DropIndex("dbo.MovieDirector", new[] { "DirectorId" });
            DropIndex("dbo.MovieDirector", new[] { "MovieId" });
            DropIndex("dbo.MovieCast", new[] { "CastId" });
            DropIndex("dbo.MovieCast", new[] { "MovieId" });
            DropTable("dbo.MovieDirector");
            DropTable("dbo.MovieCast");
            DropTable("dbo.Director");
            DropTable("dbo.Cast");
        }
    }
}
