using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Data
{
    public class MyDbContext : DbContext
    {
        // Sørg for at inkludere en korrekt DbContextOptions-konstruktor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // OnConfiguring skal være der for design-tid support, men kun hvis IsConfigured er falsk
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=NewCinemaDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            // PostalCode Configuration
            modelBuilder.Entity<PostalCode>()
                .Property(e => e.PostalCodeId)
                .ValueGeneratedNever();

            // Movie -> Genre (Many-to-Many Relationship)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId")
                );

            // Movie Duration Configuration (kommenteret ud for nu)
            // Sørg for at aktivere dette igen, hvis du bruger TimeSpan i din model
            // modelBuilder.Entity<Movie>()
            //     .Property(m => m.Duration)
            //     .HasConversion(
            //         v => v.ToString(),
            //         v => TimeSpan.Parse(v))
            //     .HasColumnType("time");

            // Screening -> Movie (One-to-Many Relationship)
            // Screening -> Movie (One-to-Many Relationship)
            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Screenings)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.NoAction); // Fjern cascading her

            // Screening -> CinemaHall (One-to-Many Relationship)
            modelBuilder.Entity<Screening>()
                .HasOne(s => s.CinemaHall)
                .WithMany(ch => ch.Screenings)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade); // Behold cascading her

          
        }
    }
}
