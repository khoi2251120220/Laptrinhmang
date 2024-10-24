using MySql.Data.MySqlClient;
using System;

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
                string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
