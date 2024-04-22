using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Transaction
    {
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public double CurrentBalance { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
    }
}
