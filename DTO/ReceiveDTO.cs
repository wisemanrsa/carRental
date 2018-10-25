using System;

namespace carRental.DTO
{
    public class ReceiveDTO
    {
        public long ClientNumber { get; set; }
        public DateTime Date { get; set; }
        public double Reading { get; set; }
    }
}