using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class AddCinemaHallDto
    {
        public string Name { get; set; } = null!;
        public int SeatCapacity { get; set; }
        public int CinemaAddressId { get; set; }
    }
}
