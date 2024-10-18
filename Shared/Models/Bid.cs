using System;

namespace Shared.Models
{
    public class Bid
    {
        public int BidID { get; set; }
        public int AuctionID { get; set; }
        public int UserID { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }

        public Auction Auction { get; set; }
        public User User { get; set; }
    }
}
