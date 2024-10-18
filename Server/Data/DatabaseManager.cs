using MySqlConnector;

using System.Collections.Generic;
// using Server.Models;
using Shared.Models;


namespace Server.Data
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // Kiểm tra xem có dữ liệu trong bảng auctions không
                var checkSql = "SELECT COUNT(*) FROM auctions";
                using (var checkCommand = new MySqlCommand(checkSql, connection))
                {
                    var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count == 0)
                    {
                        // Nếu không có dữ liệu, thực hiện seeding
                        SeedData(connection);
                    }
                }
            }
        }

        private void SeedData(MySqlConnection connection)
        {
            // Thêm users
            var userSql = @"INSERT INTO users (username, password, email) VALUES 
                            ('user1', 'password1', 'user1@example.com'),
                            ('user2', 'password2', 'user2@example.com'),
                            ('user3', 'password3', 'user3@example.com')";
            using (var command = new MySqlCommand(userSql, connection))
            {
                command.ExecuteNonQuery();
            }

            // Thêm license plates
            var plateSql = @"INSERT INTO license_plates (plate_number, description, starting_price) VALUES 
                             ('30A-12345', 'Biển số xe Hà Nội', 50000000),
                             ('51G-67890', 'Biển số xe TP.HCM', 60000000),
                             ('43A-98765', 'Biển số xe Đà Nẵng', 45000000)";
            using (var command = new MySqlCommand(plateSql, connection))
            {
                command.ExecuteNonQuery();
            }

            // Thêm auctions
            var auctionSql = @"INSERT INTO auctions (license_plate_id, start_time, end_time, current_price, status) VALUES 
                               (1, NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY), 50000000, 'active'),
                               (2, NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY), 60000000, 'active'),
                               (3, NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY), 45000000, 'active')";
            using (var command = new MySqlCommand(auctionSql, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Dữ liệu mẫu đã được thêm vào cơ sở dữ liệu.");
        }

        public List<Auction> GetAllAuctions()
        {
            var auctions = new List<Auction>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = @"
                    SELECT a.id, lp.plate_number, a.current_price, a.status, 
                           u.username as highest_bidder
                    FROM auctions a
                    JOIN license_plates lp ON a.license_plate_id = lp.id
                    LEFT JOIN bids b ON a.id = b.auction_id AND b.bid_amount = a.current_price
                    LEFT JOIN users u ON b.user_id = u.id
                    ORDER BY a.current_price DESC";

                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            auctions.Add(new Auction
                            {
                                Id = reader.GetInt32(0),
                                PlateNumber = reader.GetString(1),
                                CurrentPrice = reader.GetDecimal(2),
                                Status = reader.GetString(3),
                                HighestBidder = reader.IsDBNull(4) ? "Chưa có" : reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return auctions;
        }

    }
}
