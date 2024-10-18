using MySql.Data.MySqlClient;
using Server.Services;
using DotNetEnv;
using Server.Data;

namespace Server
{
    class Program
    {
        // private const int BUFFER_SIZE = 1024;
        // private const int PORT_NUMBER = 9999;

        static void Main(string[] args)
        {
            // Console.WriteLine("C# MySQL");
            // string connStr = "server=localhost;user=root;database=phpmyadmin;port=3306";
            // using (MySqlConnection conn = new MySqlConnection(connStr))
            // {
            //     try
            //     {
            //         Console.WriteLine("Đang kết nối đến MySQL...");
            //         conn.Open();

            //         IPAddress address = IPAddress.Parse("127.0.0.1");
            //         TcpListener listener = new TcpListener(address, PORT_NUMBER);
            //         listener.Start();
            //         Console.WriteLine($"Server đang lắng nghe trên port {PORT_NUMBER}...");

            //         using (Socket socket = listener.AcceptSocket())
            //         {
            //             byte[] data = new byte[BUFFER_SIZE];
            //             int bytesReceived = socket.Receive(data);
            //             string receivedMessage = Encoding.UTF8.GetString(data, 0, bytesReceived);

            //             string[] credentials = receivedMessage.Split(':');
            //             string userName = credentials[0];
            //             string password = credentials[1];

            //             string sql = "SELECT COUNT(*) FROM phpmyadmin.user WHERE username = @username AND password = @password";
            //             using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            //             {

            //                 cmd.Parameters.AddWithValue("@username", userName);
            //                 cmd.Parameters.AddWithValue("@password", password);

            //                 int count = Convert.ToInt32(cmd.ExecuteScalar());

            //                 if (count > 0)
            //                 {
            //                     socket.Send(Encoding.UTF8.GetBytes("Login successful"));
            //                 }
            //                 else
            //                 {
            //                     socket.Send(Encoding.UTF8.GetBytes("Invalid username or password."));
            //                 }
            //             }
            //         }
            //         listener.Stop();
            //     }
            //     catch (Exception ex)
            //     {
            //         Console.WriteLine("Lỗi: " + ex);
            //     }
            // }
            // string connectionString = "server=localhost;user=user;password=password;database=auction_db";
            //get to .env file
            Env.Load();
            string connectionString = "server=localhost;" +
                                    $"user={Environment.GetEnvironmentVariable("DB_USER")};" +
                                    $"password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                                    $"database={Environment.GetEnvironmentVariable("DB_NAME")}";

            var dbManager = new DatabaseManager(connectionString);
            dbManager.InitializeDatabase();

            var auctionService = new AuctionService(connectionString);

            SocketServer server = new("127.0.0.1", 8888, auctionService);
            server.Start();
        }

        static String getPassword(String username)
        {
            string passwordReal = null;
            Console.WriteLine("C# MySQL");
            string connStr = "server=localhost;user=root;database=phpmyadmin;port=3306";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    Console.WriteLine("Đang kết nối đến MySQL...");
                    conn.Open();
                    string sql = "SELECT password FROM phpmyadmin.user WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            passwordReal = rdr.GetString(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return passwordReal;
        }
    }
}
