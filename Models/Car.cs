using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carRental.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RegistrationNumber { get; set; }
        public string ColorCode { get; set; }
        public Color Color { get; set; }
        public DateTime LastServiceDate { get; set; }
        public string RentalAgencyCode { get; set; }
        public RentalAgency RentalAgency { get; set; }
        public string CarTypeCode { get; set; }
        public CarType CarType { get; set; }
        public Boolean Available { get; set; }
    }
}