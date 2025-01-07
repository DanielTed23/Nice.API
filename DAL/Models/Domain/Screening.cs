using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Screening
    {
        public int ScreeningId { get; set; } // Primær nøgle
        public int MovieId { get; set; } // Reference til filmen
        public int CinemaHallId { get; set; } // Reference til biografsalen
        public decimal StartTime { get; set; } // Starttidspunkt for visningen
        public decimal EndTime { get; set; } // Sluttidspunkt for visningen

        // Navigation Properties
        public Movie Movie { get; set; } = null!;
        public CinemaHall CinemaHall { get; set; } = null!;
    }
}
