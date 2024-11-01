using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using DotNetEnv;
using Server.Services;
using Server.Data;
using System.Text.Json;
using Shared.Models;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Load .env file
            Env.Load();

            // Initialize database
            var dbContext = new DatabaseContext();
            await dbContext.InitializeDatabase();

            var auctionService = new AuctionService(dbContext);

            // Set up TCP listener
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started on port 5000");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client, auctionService);
            }
        }

        static async Task HandleClientAsync(TcpClient client, AuctionService auctionService)
        {
            try
            {
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream);
                using var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                while (true)
                {
                    string? command = await reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(command)) break;

                    string response = await ProcessCommand(command, auctionService);
                    await writer.WriteLineAsync(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        static async Task<string> ProcessCommand(string command, AuctionService auctionService)
        {
            try
            {
                var parts = command.Split('|');
                switch (parts[0].ToLower())
                {
                    case "login":
                        if (parts.Length != 3)
                            return JsonSerializer.Serialize<User>(null); // Return null for invalid format

                        var user = await auctionService.Login(parts[1], parts[2]);
                        return JsonSerializer.Serialize(user);

                    case "register":
                        if (parts.Length != 4)
                            return "Invalid command format";

                        var newUser = new User
                        {
                            Username = parts[1],
                            Password = parts[2], // In production, should hash password
                            Email = parts[3]
                        };

                        bool registerSuccess = await auctionService.RegisterUser(newUser);
                        return registerSuccess ? "Registration successful" : "Registration failed";

                    case "getauctions":
                        var auctions = await auctionService.GetActiveAuctions();
                        return JsonSerializer.Serialize(auctions);

                    case "getbids":
                        if (parts.Length != 2) return "Invalid command format";
                        var bids = await auctionService.GetAuctionBids(int.Parse(parts[1]));
                        return JsonSerializer.Serialize(bids);

                    case "placebid":
                        if (parts.Length != 4) return "Invalid command format";
                        var success = await auctionService.PlaceBid(
                            int.Parse(parts[1]), // auctionId
                            int.Parse(parts[2]), // userId
                            decimal.Parse(parts[3]) // amount
                        );
                        return success ? "Bid placed successfully" : "Failed to place bid";
                    case "getinactiveauctions":  // Thêm lệnh mới
                        var inactiveAuctions = await auctionService.GetInactiveAuctions();
                        return JsonSerializer.Serialize(inactiveAuctions);
                    default:
                        return "Unknown command";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
