using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        static void Main(string[] args)
        {
            Console.WriteLine("C# MySQL");
            string connStr = "server=localhost;user=root;database=auction_db;password=1234;port=3306";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    Console.WriteLine("Đang kết nối đến MySQL...");
                    conn.Open();

                    IPAddress address = IPAddress.Parse("127.0.0.1");
                    TcpListener listener = new TcpListener(address, PORT_NUMBER);
                    listener.Start();
                    Console.WriteLine($"Server đang lắng nghe trên port {PORT_NUMBER}...");

                    using (Socket socket = listener.AcceptSocket())
                    {
                        byte[] data = new byte[BUFFER_SIZE];
                        int bytesReceived = socket.Receive(data);
                        string receivedMessage = Encoding.UTF8.GetString(data, 0, bytesReceived);

                        string[] credentials = receivedMessage.Split(':');
                        string userName = credentials[0];
                        string password = credentials[1];

                        string sql = "SELECT COUNT(*) FROM auction_db.user WHERE username = @username AND password = @password";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", userName);
                            cmd.Parameters.AddWithValue("@password", password);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count > 0)
                            {
                                socket.Send(Encoding.UTF8.GetBytes("Login successful"));
                            }
                            else
                            {
                                socket.Send(Encoding.UTF8.GetBytes("Invalid username or password."));
                            }
                        }
                    }
                    listener.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex);
                }
            }
        }
    }
}
