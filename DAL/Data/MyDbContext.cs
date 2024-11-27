using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DAL.Data
{
    public class MyDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<PostalCode > PostalCodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // Fluent API

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=NewCinemaDb;Trusted_Connection=True;TrustServerCertificate=True");

            //"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubIntroDatabase"
            // "Server=(localdb)\\MSSQLLocalDB;Database=NewCinemaDb;Trusted_Connection=True;TrustServerCertificate=True"
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            ///////
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                      .HasMaxLength(50);
                entity.Property(e => e.LastName)
                      .HasMaxLength(50);
                entity.Property(e => e.Email)
                      .HasMaxLength(100);
                entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()");
            });

            // PostalCode   
            // We do not want identity on this PK
            modelBuilder.Entity<PostalCode>()
                .Property(e => e.PostalCodeId)
                .ValueGeneratedNever();

            // Movie
            modelBuilder.Entity<Movie>()
                .Property(e => e.Rating)
                .HasPrecision(3, 1);
        }
    }
}
