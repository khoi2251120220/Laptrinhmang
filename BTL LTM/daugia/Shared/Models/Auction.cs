namespace Shared.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int LicensePlateId { get; set; }
        public string PlateNumber { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Status { get; set; }
        public string HighestBidder { get; set; }
    }
}
