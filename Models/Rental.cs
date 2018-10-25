using System;
using System.ComponentModel.DataAnnotations;

namespace carRental.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public long ClientNumber { get; set; }
        public Client Client { get; set; }
        public string CarRegistrationCode { get; set; }
        public Car Car { get; set; }
        public double Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PickLoc { get; set; }
        public string  ReturnLoc { get; set; }

    }
}