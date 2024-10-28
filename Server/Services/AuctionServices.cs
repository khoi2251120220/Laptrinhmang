using Server.Data;
using MySql.Data.MySqlClient;
using Shared.Models;
using Shared.Interfaces;
using System.Data;

namespace Server.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly DatabaseContext _dbContext;

        public AuctionService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Auction>> GetActiveAuctions()
        {
            var auctions = new List<Auction>();
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT * FROM auctions WHERE status = 'Active' AND end_time > NOW()";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                auctions.Add(new Auction
                {
                    Id = reader.GetInt32("id"),
                    LicensePlateNumber = reader.GetString("license_plate_number"),
                    StartingPrice = reader.GetDecimal("starting_price"),
                    CurrentPrice = reader.GetDecimal("current_price"),
                    StartTime = reader.GetDateTime("start_time"),
                    EndTime = reader.GetDateTime("end_time"),
                    WinnerId = reader.IsDBNull("winner_id") ? null : reader.GetInt32("winner_id"),
                    Status = reader.GetString("status")
                });
            }

            return auctions;
        }

        public async Task<bool> PlaceBid(int auctionId, int userId, decimal amount)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();
            using var transaction = await conn.BeginTransactionAsync();

            try
            {
                // Check if auction is active and amount is higher than current price
                var checkSql = @"SELECT current_price, status, end_time 
                               FROM auctions 
                               WHERE id = @auctionId";
                using var checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@auctionId", auctionId);
                using var reader = await checkCmd.ExecuteReaderAsync();

                if (!await reader.ReadAsync())
                    return false;

                var currentPrice = reader.GetDecimal("current_price");
                var status = reader.GetString("status");
                var endTime = reader.GetDateTime("end_time");

                if (status != "Active" || DateTime.Now > endTime || amount <= currentPrice)
                    return false;

                reader.Close();

                // Insert bid
                var insertBidSql = @"INSERT INTO bids (auction_id, user_id, amount, bid_time)
                                   VALUES (@auctionId, @userId, @amount, NOW())";
                using var insertBidCmd = new MySqlCommand(insertBidSql, conn);
                insertBidCmd.Parameters.AddWithValue("@auctionId", auctionId);
                insertBidCmd.Parameters.AddWithValue("@userId", userId);
                insertBidCmd.Parameters.AddWithValue("@amount", amount);
                await insertBidCmd.ExecuteNonQueryAsync();

                // Update auction current price
                var updateAuctionSql = @"UPDATE auctions 
                                       SET current_price = @amount 
                                       WHERE id = @auctionId";
                using var updateAuctionCmd = new MySqlCommand(updateAuctionSql, conn);
                updateAuctionCmd.Parameters.AddWithValue("@amount", amount);
                updateAuctionCmd.Parameters.AddWithValue("@auctionId", auctionId);
                await updateAuctionCmd.ExecuteNonQueryAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<List<Bid>> GetAuctionBids(int auctionId)
        {
            var bids = new List<Bid>();
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT * FROM bids WHERE auction_id = @auctionId ORDER BY amount DESC";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@auctionId", auctionId);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                bids.Add(new Bid
                {
                    Id = reader.GetInt32("id"),
                    AuctionId = reader.GetInt32("auction_id"),
                    UserId = reader.GetInt32("user_id"),
                    Amount = reader.GetDecimal("amount"),
                    BidTime = reader.GetDateTime("bid_time")
                });
            }

            return bids;
        }

        public async Task<bool> RegisterUser(User user)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            // Check if username already exists
            using (var checkCmd = new MySqlCommand(
                "SELECT COUNT(*) FROM users WHERE username = @username",
                conn))
            {
                checkCmd.Parameters.AddWithValue("@username", user.Username);
                var count = Convert.ToInt32(await checkCmd.ExecuteScalarAsync());
                if (count > 0)
                    return false;
            }

            try
            {
                using var cmd = new MySqlCommand(
                    @"INSERT INTO users (username, password, email)
                      VALUES (@username, @password, @email)",
                    conn);

                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password); // Should hash password in production
                cmd.Parameters.AddWithValue("@email", user.Email);

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> Login(string username, string password)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(
                @"SELECT id, username, password, email 
                  FROM users 
                  WHERE username = @username AND password = @password",
                conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password); // Should hash password in production

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("password"), // Consider not sending password back
                    Email = reader.GetString("email")
                };
            }

            return null;
        }
    }
}
