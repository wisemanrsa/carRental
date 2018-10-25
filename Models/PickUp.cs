using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carRental.Models
{
    public class PickUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClientNumber { get; set; }
        public DateTime Date { get; set; }
    }
}