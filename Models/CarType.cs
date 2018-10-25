using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carRental.Models
{
    public class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double EngineSize { get; set; }
        public double Tarrif { get; set; }
        public bool Conditioner { get; set; }
        public bool Automatic { get; set; }
        public string FuelType { get; set; }
        public char CarSizeCode { get; set; }
        public Size Size { get; set; }
    }
}