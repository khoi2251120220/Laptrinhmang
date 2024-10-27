using MySql.Data.MySqlClient;
using System;
using System.Data;
using client;
namespace Server
{
    public class Database
    {
        private string connectionString = "server=localhost;user=root;database=phpmyadmin;port=3306";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Method to register a new user
        public bool RegisterUser(string username, string password, string email)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO user (username, password, email) VALUES (@username, @password, @Email)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public bool ValidateLogin(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT password FROM user WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader.GetString("password");
                            string hashedPassword = UserService.HashPassword(password);
                            Console.WriteLine("Stored Hashed Password in DB: " + storedHashedPassword);
                            Console.WriteLine("Hashed Password for Login: " + hashedPassword);
                            return storedHashedPassword == hashedPassword;
                        }
                    }
                }
            }
            return false;
        }
        // Phương thức để lấy thông tin người dùng
        public string? LoadUserInfo(string username)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT username, product_name FROM user WHERE username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userInfo = $"Tên tài khoản: {reader["username"]}";
                            return userInfo; // Trả về thông tin người dùng
                        }
                    }
                }
            }
            return null; // Trả về null nếu không tìm thấy
        }
        //Phương thức để lấy thông tin phiên đấu giá theo username
        public string LoadAuctionInfo(string username)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT AuctionID, ProductName, StartTime, EndTime FROM Auction WHERE Username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string auctionInfo = $"Mã phiên đấu giá: {reader["AuctionID"]}, Tên sản phẩm: {reader["ProductName"]}, Thời gian bắt đầu: {reader["StartTime"]}, Thời gian kết thúc: {reader["EndTime"]}";
                            return auctionInfo;
                        }
                    }
                }
            }
            return "Không tìm thấy thông tin phiên đấu giá.";
        }
        //Phương thức lấy giá đấu 
        public decimal GetBidAmount(string username, int auctionId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT BidAmount FROM Bids WHERE Username = @username AND AuctionID = @auctionId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@auctionId", auctionId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
            }
            return 0;
        }

        public bool SavePaymentHistory(string username, string transactionInfo, decimal amount, string paymentMethod)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO PaymentHistory (user_id, transaction_info, amount, payment_method_id, status) " +
                       "VALUES ((SELECT user_id FROM user WHERE username = @username), @transactionInfo, @amount, " +
                       "(SELECT payment_method_id FROM PaymentMethods WHERE method_name = @paymentMethod), @status)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@transactionInfo", transactionInfo);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@status", "Thành công");

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; // Trả về true nếu lưu thành công
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return false; // Trả về false nếu có lỗi
                    }
                }
            }
        }

        public DataTable GetPaymentHistory(string username)
        {
            DataTable paymentHistoryTable = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT ph.transaction_id AS 'Mã số', u.username AS 'Người dùng', ph.transaction_info AS 'Thông tin biến số', " +
                               "ph.amount AS 'Số tiền', pm.method_name AS 'Phương thức thanh toán', ph.status AS 'Trạng thái' " +
                               "FROM PaymentHistory ph " +
                               "JOIN user u ON ph.user_id = u.user_id " +
                               "JOIN PaymentMethods pm ON ph.payment_method_id = pm.payment_method_id " +
                               "WHERE u.username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(paymentHistoryTable);
                    }
                }
            }
            return paymentHistoryTable;
        }
   }
}


