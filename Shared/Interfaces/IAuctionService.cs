using Shared.Models;

namespace Shared.Interfaces
{
    public interface IAuctionService
    {
        Task<string> GetStatus(int auctionId);
        Task<List<Auction>> GetActiveAuctions();
        Task<List<Auction>> GetInactiveAuctions();
        Task<bool> PlaceBid(int auctionId, int userId, decimal amount);
        Task<List<Bid>> GetAuctionBids(int auctionId);
        Task<bool> RegisterUser(User user);
        Task<User> Login(string username, string password);
        Task<bool> UpdateAuction(Auction updatedAuction);
        Task<bool> DeleteAuction(int auctionId);
        Task<bool> AddAuction(Auction newAuction);
    }
}
