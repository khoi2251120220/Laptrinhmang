namespace Shared.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string LicensePlateNumber { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? WinnerId { get; set; }
        public string Status { get; set; } // "Active", "Completed", "Cancelled"
    }
}
