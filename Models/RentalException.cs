using System;

namespace carRental.Models
{
    public class RentalException : Exception
    {
        public RentalException(string message, Exception ex = null) : base(message, ex)
        {
        }
    }
}