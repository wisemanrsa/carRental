using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carRental.Models
{
    public class Employee
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLength(4)]
        [Required]
        public long  StaffNumber { get; set; }
        [MinLength(13)]
        [MaxLength(13)]
        [Required]
        public long IdNumber { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Initials { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Number { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateOfAppointment { get; set; }
        [Required]
        public string JobCode { get; set; }
        public Job Job { get; set; }
    }
}