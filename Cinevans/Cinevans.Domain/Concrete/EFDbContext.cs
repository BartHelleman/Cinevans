using Cinevans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinevans.Domain.Concrete {
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class EFDbContext:DbContext {

        public EFDbContext()
            : base("CinevansDB") {

        }

        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Row> Row { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Viewing> Viewing { get; set; }
        public DbSet<NewsLetter> NewsLetter { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Review> Reiew { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Movie>()
                     .HasMany(m => m.Rates)
                     .WithMany(i => i.Movies)
                     .Map(t => t.MapLeftKey("MovieId")
                         .MapRightKey("RateId")
                         .ToTable("MovieRate"));

            modelBuilder.Entity<Movie>()
                 .HasMany(m => m.Genres)
                 .WithMany(i => i.Movies)
                 .Map(t => t.MapLeftKey("MovieId")
                     .MapRightKey("GenreId")
                     .ToTable("MovieGenre"));

            modelBuilder.Entity<Movie>()
                 .HasMany(m => m.Casts)
                 .WithMany(i => i.Movies)
                 .Map(t => t.MapLeftKey("MovieId")
                     .MapRightKey("CastId")
                     .ToTable("MovieCast"));

            modelBuilder.Entity<Movie>()
                 .HasMany(m => m.Directors)
                 .WithMany(i => i.Movies)
                 .Map(t => t.MapLeftKey("MovieId")
                     .MapRightKey("DirectorId")
                     .ToTable("MovieDirector"));

        }

    }
}
