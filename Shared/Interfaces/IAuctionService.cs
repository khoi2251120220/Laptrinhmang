using Shared.Models;

namespace Shared.Interfaces
{
    public interface IAuctionService
    {
        Task<List<Auction>> GetActiveAuctions();
        Task<bool> PlaceBid(int auctionId, int userId, decimal amount);
        Task<List<Bid>> GetAuctionBids(int auctionId);
        Task<bool> RegisterUser(User user);
        Task<User> Login(string username, string password);
    }
}
