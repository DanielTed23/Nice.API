using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; } // Ny DbSet til CinemaHalls
        public DbSet<CinemaAddress> CinemaAddresses { get; set; } // Ny DbSet til CinemaAddress

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique(); // Tilføj unik constraint
                entity.Property(e => e.CreateDate).HasDefaultValueSql("GETDATE()");
            });

            // PostalCode Configuration
            modelBuilder.Entity<PostalCode>()
                .Property(e => e.PostalCodeId)
                .ValueGeneratedNever();

            // Movie Configuration
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Rating)
                      .HasPrecision(3, 2) // Maksimal præcision for decimaler
                      .HasDefaultValue(0) // Standardværdi for rating
                      .HasAnnotation("Range", "0-5"); // Begrænsning mellem 0 og 5

                // Movie -> CinemaHall (Many-to-One Relationship)
                entity.HasOne(m => m.CinemaHall)
                      .WithMany(ch => ch.Movies)
                      .HasForeignKey(m => m.CinemaHallId)
                      .OnDelete(DeleteBehavior.Cascade); // Cascade sletning
            });

            // Movie -> Genre (Many-to-Many Relationship)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId")
                );

            // Screening -> Movie (One-to-Many Relationship)
            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Screenings)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Screening -> CinemaHall (One-to-Many Relationship)
            modelBuilder.Entity<Screening>()
                .HasOne(s => s.CinemaHall)
                .WithMany(ch => ch.Screenings)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade);

            // CinemaHall -> CinemaAddress (One-to-One Relationship)
            modelBuilder.Entity<CinemaHall>()
                .HasOne(ch => ch.CinemaAddress)
                .WithOne(ca => ca.CinemaHall)
                .HasForeignKey<CinemaHall>(ch => ch.CinemaAddressId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade sletning for adresser
        }
    }
}
