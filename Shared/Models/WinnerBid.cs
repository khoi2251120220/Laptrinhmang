namespace Shared.Models
{
    public class WinnerBid
    {
        public int BidID { get; set; }
        public int AuctionID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }

        public Auction Auction { get; set; }
        public User User { get; set; }
    }
}
