using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public List<Bid> Bids { get; set; }
        public List<WinnerBid> WinnerBids { get; set; }
    }
}
