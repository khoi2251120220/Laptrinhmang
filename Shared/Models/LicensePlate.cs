using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class LicensePlate
    {
        public int PlateID { get; set; }
        public string PlateNumber { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        public List<Auction> Auctions { get; set; }
    }
}
