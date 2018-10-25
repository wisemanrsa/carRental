using System;

namespace carRental.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public long ClientNumber { get; set; }
        public double amount { get; set; }
        public DateTime Date { get; set; }
    }
}