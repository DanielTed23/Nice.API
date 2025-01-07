using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    internal class Seat
    {
        public int SeatId { get; set; }
        public int CinemaHallId { get; set; } // Reference til biografsalen
        public string SeatNumber { get; set; } = null!; // F.eks. "A1", "B12"
        public bool IsAvailable { get; set; } = true; // Angiver, om sædet er ledigt

        // Navigation Property
        public CinemaHall CinemaHall { get; set; } = null!;
    }
}
