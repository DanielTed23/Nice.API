using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Domain
{
    public class CinemaAddress
    {
        [Key]
        public int CinemaAddressId { get; set; } // Primær nøgle
        public string Street { get; set; } = null!; // Gadenavn og nummer
        public string City { get; set; } = null!; // Byen
        public int PostalCodeId { get; set; } // Reference til PostalCode

        // Navigation Property til PostalCode
        public PostalCode PostalCode { get; set; } = null!;

        // Navigation Property til CinemaHall (One-to-One)
        public CinemaHall CinemaHall { get; set; } = null!;
    }
}
