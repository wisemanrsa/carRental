using System.Collections.Generic;
using carRental.Models;

namespace carRental.DTO
{
    public class InvoiceDTO
    {
        public double Amount { get; set; }
        public double Deposit { get; set; }
        public bool AdditionalFees { get; set; }
        public List<Payment> Payments { get; set; }
        public long ClientNumber { get; set; }
        public string CarReg { get; set; }
    }
}