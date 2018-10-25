namespace carRental.DTO
{
    public class RentalDTO
    {
        public long ClientNumber { get; set; }
        public string CarRegistrationCode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PickLoc { get; set; }
        public string  ReturnLoc { get; set; }
    }
}