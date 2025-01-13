using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    internal class CinemaAddressDto
    {
        public int CinemaAddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCodeId { get; set; }
    }
}
