﻿using Server.Data;
using MySql.Data.MySqlClient;
using Shared.Models;
using Shared.Interfaces;
using System.Data;

namespace Server.Services
{
    public class AuctionService : IAuctionService
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
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

        public async Task<List<Auction>> GetInactiveAuctions()
        {
            var auctions = new List<Auction>();
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT * FROM auctions WHERE status IN ('Completed', 'Cancelled')  OR end_time < NOW()";
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

                var insertBidSql = @"INSERT INTO bids (auction_id, user_id, amount, bid_time)
                                   VALUES (@auctionId, @userId, @amount, NOW())";
                using var insertBidCmd = new MySqlCommand(insertBidSql, conn);
                insertBidCmd.Parameters.AddWithValue("@auctionId", auctionId);
                insertBidCmd.Parameters.AddWithValue("@userId", userId);
                insertBidCmd.Parameters.AddWithValue("@amount", amount);
                await insertBidCmd.ExecuteNonQueryAsync();

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

            // Kiểm tra xem tên đăng nhập đã tồn tại chưa
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
                string hashedPassword = HashPassword(user.Password); // Mã hóa mật khẩu
                using var cmd = new MySqlCommand(
                    @"INSERT INTO users (username, password, email)
              VALUES (@username, @password, @email)",
                    conn);

                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", hashedPassword); // Lưu mật khẩu đã mã hóa
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
            string hashedPassword = HashPassword(password); // Mã hóa mật khẩu
            using var cmd = new MySqlCommand(
                @"SELECT id, username, password, email, role 
          FROM users 
          WHERE username = @username AND password = @password",
                conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", hashedPassword); // So sánh với mật khẩu đã mã hóa

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("password"), // Cân nhắc không trả lại mật khẩu
                    Email = reader.GetString("email"),
                    Role = reader.GetString("role")
                };
            }

            return null;
        }


        public async Task<string> GetStatus(int auctionId)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT status FROM auctions WHERE id = @auctionId";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@auctionId", auctionId);

            var status = await cmd.ExecuteScalarAsync();
            return status?.ToString(); // Tr? v? tr?ng thái ho?c null n?u không t́m th?y
        }

        public async Task<bool> UpdateAuction(Auction updatedAuction)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            //Kiểm tra phiên đấu giá tồn tại chưa
            var checkSql = @"SELECT status FROM auctions WHERE id = @auctionId";
            using var checkCmd = new MySqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@auctionId", updatedAuction.Id);

            var status = await checkCmd.ExecuteScalarAsync();
            if (status == null || status.ToString() != "Active")
                return false; 

            try
            {
                //Cập nhật
                var updateSql = @"UPDATE auctions 
                          SET license_plate_number = @licensePlateNumber, 
                              starting_price = @startingPrice, 
                              current_price = @currentPrice, 
                              start_time = @startTime, 
                              end_time = @endTime, 
                              status = @status 
                          WHERE id = @auctionId";

                using var updateCmd = new MySqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@licensePlateNumber", updatedAuction.LicensePlateNumber);
                updateCmd.Parameters.AddWithValue("@startingPrice", updatedAuction.StartingPrice);
                updateCmd.Parameters.AddWithValue("@currentPrice", updatedAuction.CurrentPrice);
                updateCmd.Parameters.AddWithValue("@startTime", updatedAuction.StartTime);
                updateCmd.Parameters.AddWithValue("@endTime", updatedAuction.EndTime);
                updateCmd.Parameters.AddWithValue("@status", updatedAuction.Status);
                updateCmd.Parameters.AddWithValue("@auctionId", updatedAuction.Id);

                var rowsAffected = await updateCmd.ExecuteNonQueryAsync();
                return rowsAffected > 0; 
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteAuction(int auctionId)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();
            var checkSql = @"SELECT COUNT(*) FROM auctions WHERE id = @auctionId";
            using var checkCmd = new MySqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@auctionId", auctionId);
            var count = Convert.ToInt32(await checkCmd.ExecuteScalarAsync());

            if (count == 0)
                return false; 

            try
            {
           
                var deleteSql = @"DELETE FROM auctions WHERE id = @auctionId";
                using var deleteCmd = new MySqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@auctionId", auctionId);
                var rowsAffected = await deleteCmd.ExecuteNonQueryAsync();

                return rowsAffected > 0; 
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddAuction(Auction newAuction)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"INSERT INTO auctions (license_plate_number, starting_price, current_price, start_time, end_time, status)
                        VALUES (@licensePlateNumber, @startingPrice, @currentPrice, @startTime, @endTime, @status)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@licensePlateNumber", newAuction.LicensePlateNumber);
            cmd.Parameters.AddWithValue("@startingPrice", newAuction.StartingPrice);
            cmd.Parameters.AddWithValue("@currentPrice", newAuction.CurrentPrice);
            cmd.Parameters.AddWithValue("@startTime", newAuction.StartTime);
            cmd.Parameters.AddWithValue("@endTime", newAuction.EndTime);
            cmd.Parameters.AddWithValue("@status", newAuction.Status);

            var rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateWinner(int auctionId)
        {
            using var conn = _dbContext.GetConnection();
            await conn.OpenAsync();

            var sql = @"SELECT id, auction_id, user_id, amount 
                FROM bids 
                WHERE auction_id = @auctionId 
                ORDER BY amount DESC 
                LIMIT 1";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@auctionId", auctionId);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var winnerId = reader.GetInt32("user_id");
                reader.Close();

                var updateSql = @"UPDATE auctions 
                          SET winner_id = @winnerId, status = 'Completed'
                          WHERE id = @auctionId";

                using var updateCmd = new MySqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@winnerId", winnerId);
                updateCmd.Parameters.AddWithValue("@auctionId", auctionId);

                var rowsAffected = await updateCmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }

            return false; // Không có lượt đấu giá nào
        }



    }
}
