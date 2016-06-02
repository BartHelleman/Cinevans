namespace Cinevans.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class Initializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        Accessbility = c.Boolean(nullable: false),
                        is3D = c.Boolean(nullable: false),
                        Cinema_CinemaId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Cinema", t => t.Cinema_CinemaId)
                .Index(t => t.Cinema_CinemaId);
            
            CreateTable(
                "dbo.Row",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        RowNumber = c.Int(nullable: false),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.RowId)
                .ForeignKey("dbo.Room", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.Seat",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        SeatNumber = c.Int(nullable: false),
                        RowId = c.Int(nullable: false),
                        IsTaken = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Row", t => t.RowId, cascadeDelete: true)
                .Index(t => t.RowId);
            
            CreateTable(
                "dbo.Viewing",
                c => new
                    {
                        ViewingId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViewingId)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Duration = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        MovieImage = c.String(),
                        Description = c.String(),
                        is3D = c.Boolean(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Language = c.String(),
                        HasSubtitles = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RateId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        SeatId = c.Int(nullable: false),
                        ViewingId = c.Int(nullable: false),
                        RateId = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Rate", t => t.RateId, cascadeDelete: true)
                .ForeignKey("dbo.Seat", t => t.SeatId, cascadeDelete: true)
                .ForeignKey("dbo.Viewing", t => t.ViewingId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.SeatId)
                .Index(t => t.ViewingId)
                .Index(t => t.RateId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.MovieRate",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        RateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.RateId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Rate", t => t.RateId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.RateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.Room", "Cinema_CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.Ticket", "ViewingId", "dbo.Viewing");
            DropForeignKey("dbo.Ticket", "SeatId", "dbo.Seat");
            DropForeignKey("dbo.Ticket", "RateId", "dbo.Rate");
            DropForeignKey("dbo.Viewing", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Viewing", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieRate", "RateId", "dbo.Rate");
            DropForeignKey("dbo.MovieRate", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Row", "Room_RoomId", "dbo.Room");
            DropForeignKey("dbo.Seat", "RowId", "dbo.Row");
            DropIndex("dbo.MovieRate", new[] { "RateId" });
            DropIndex("dbo.MovieRate", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.Ticket", new[] { "Order_OrderId" });
            DropIndex("dbo.Ticket", new[] { "RateId" });
            DropIndex("dbo.Ticket", new[] { "ViewingId" });
            DropIndex("dbo.Ticket", new[] { "SeatId" });
            DropIndex("dbo.Viewing", new[] { "RoomId" });
            DropIndex("dbo.Viewing", new[] { "MovieId" });
            DropIndex("dbo.Seat", new[] { "RowId" });
            DropIndex("dbo.Row", new[] { "Room_RoomId" });
            DropIndex("dbo.Room", new[] { "Cinema_CinemaId" });
            DropTable("dbo.MovieRate");
            DropTable("dbo.MovieGenre");
            DropTable("dbo.Order");
            DropTable("dbo.Ticket");
            DropTable("dbo.Rate");
            DropTable("dbo.Genre");
            DropTable("dbo.Movie");
            DropTable("dbo.Viewing");
            DropTable("dbo.Seat");
            DropTable("dbo.Row");
            DropTable("dbo.Room");
            DropTable("dbo.Cinema");
        }
    }
}