using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class UpdateUserRequestDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;   // NULL! ER "null forgiving operator".
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int PostalCodeId { get; set; }
    }
}
