using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Domain
{
    public class CinemaHall
    {
        [Key]
        public int CinemaHallId { get; set; } // Primær nøgle
        public string Name { get; set; } = null!; // Navn på biografsalen
        public int SeatCapacity { get; set; } // Antal sæder i salen
        public int CinemaAddressId { get; set; } // Reference til CinemaAddress

        // Navigation Property til CinemaAddress (One-to-One)
        public CinemaAddress CinemaAddress { get; set; } = null!;

        // Navigation Properties
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>(); // Relation til screenings
        public ICollection<Movie> Movies { get; set; } = new List<Movie>(); // Relation til Movies
    }
}
