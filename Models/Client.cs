using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carRental.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLength(4)]
        public long ClientNumber { get; set; }
        [MinLength(13)]
        [MaxLength(13)]
        public long IdNumber { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Sex { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Suburb { get; set; }
    }
}