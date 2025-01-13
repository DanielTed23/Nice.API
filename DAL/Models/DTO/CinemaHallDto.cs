using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class CinemaHallDto
    {
        public int CinemaHallId { get; set; }
        public string Name { get; set; }
        public int SeatCapacity { get; set; }
        public int CinemaAddressId { get; set; } // Kun ID'et
    }
}
