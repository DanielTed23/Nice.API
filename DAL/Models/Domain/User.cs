using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        // Navigation Property
        public PostalCode PostalCode { get; set; }
        public int PostalCodeId { get; set; }
    }
}
