using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }
        public int PlateID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Status { get; set; }

        public LicensePlate LicensePlate { get; set; }
        public List<Bid> Bids { get; set; }
        public WinnerBid WinnerBid { get; set; }
    }

}
