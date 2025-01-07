using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class CinemaAddress
    {
        public int CinemaAddressId { get; set; } // Primær nøgle
        public string Street { get; set; } = null!; // Gadenavn og nummer
        public string City { get; set; } = null!; // Byen
        public int PostalCodeId { get; set; } // Reference til PostalCode

        // Navigation Property til PostalCode
        public PostalCode PostalCode { get; set; } = null!;

        // Navigation Property til CinemaHall
        public ICollection<CinemaHall> CinemaHalls { get; set; } = new List<CinemaHall>();
    }
}

