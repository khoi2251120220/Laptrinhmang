using System.Collections.Generic;

using Shared.Models;
using Server.Data;

namespace Server.Services
{
    public class AuctionService
    {
        private readonly DatabaseManager _dbManager;

        public AuctionService(string connectionString)
        {
            _dbManager = new DatabaseManager(connectionString);
        }

        public List<Auction> GetAllAuctions()
        {
            return _dbManager.GetAllAuctions();
        }

    }
}
