using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!; // Ex: Credit Card, PayPal
        public int UserId { get; set; } // Reference til brugeren, der betaler


        // Navigation Property
        public User User { get; set; } = null!;
    }
}
