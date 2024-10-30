using MySql.Data.MySqlClient;

namespace Server.Data
{
    public class UserService
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext()
        {
            _connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ??
<<<<<<< HEAD
                              "server=localhost;database=phpmyadmin;user=root;";
=======
                              "server=localhost;database=auction_db;user=root;password=1234";
>>>>>>> 0809fb1db1f84e257402f7f255322e4bd7ec05e8
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task InitializeDatabase()
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            // Create tables if they don't exist
            var createTables = @"
                CREATE TABLE IF NOT EXISTS users (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    username VARCHAR(50) UNIQUE NOT NULL,
                    password VARCHAR(100) NOT NULL,
                    email VARCHAR(100) NOT NULL
                );

                CREATE TABLE IF NOT EXISTS auctions (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    license_plate_number VARCHAR(20) NOT NULL,
                    starting_price DECIMAL(10,2) NOT NULL,
                    current_price DECIMAL(10,2) NOT NULL,
                    start_time DATETIME NOT NULL,
                    end_time DATETIME NOT NULL,
                    winner_id INT,
                    status VARCHAR(20) NOT NULL,
                    FOREIGN KEY (winner_id) REFERENCES users(id)
                );

                CREATE TABLE IF NOT EXISTS bids (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    auction_id INT NOT NULL,
                    user_id INT NOT NULL,
                    amount DECIMAL(10,2) NOT NULL,
                    bid_time DATETIME NOT NULL,
                    FOREIGN KEY (auction_id) REFERENCES auctions(id),
                    FOREIGN KEY (user_id) REFERENCES users(id)
                );";

            using var cmd = new MySqlCommand(createTables, conn);
            await cmd.ExecuteNonQueryAsync();

            // Insert sample data if tables are empty
            if (!await TableHasData(conn, "users"))
            {
                var insertSampleData = @"
                    INSERT INTO users (username, password, email) VALUES
                    ('user1', 'password123', 'user1@example.com'),
                    ('user2', 'password123', 'user2@example.com');

                    INSERT INTO auctions (license_plate_number, starting_price, current_price, 
                                        start_time, end_time, status) VALUES
                    ('51F-123.45', 1000000, 1000000, NOW(), DATE_ADD(NOW(), INTERVAL 1 DAY), 'Active'),
                    ('51F-678.90', 2000000, 2000000, NOW(), DATE_ADD(NOW(), INTERVAL 1 DAY), 'Active');";

                using var cmdInsert = new MySqlCommand(insertSampleData, conn);
                await cmdInsert.ExecuteNonQueryAsync();
            }
        }

        private async Task<bool> TableHasData(MySqlConnection conn, string tableName)
        {
            using var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {tableName}", conn);
            var count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return count > 0;
        }
    }
}
