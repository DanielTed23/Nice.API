using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class CinemaHall

    {

        public int CinemaHallId { get; set; } // Primær nøgle
        public string Name { get; set; } = null!; // Navn på biografsalen
        public int SeatCapacity { get; set; } // Antal sæder i salen
    
        // Navigation Property
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>(); // Relation til screenings


        public CinemaAddress CinemaAddress { get; set; } = null!;
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}

