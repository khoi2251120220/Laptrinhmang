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

        /// <summary>
        /// Handles communication with a connected client asynchronously.
        /// </summary>
        /// <param name="client">The TcpClient instance representing the connected client.</param>
        /// <param name="auctionService">The auction service instance that handles auction-related operations.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method:
        /// - Establishes stream communication with the client
        /// - Continuously reads commands from the client
        /// - Processes each command through the auction service
        /// - Sends responses back to the client
        /// - Handles connection cleanup when the client disconnects or an error occurs
        /// </remarks>
        /// <exception cref="Exception">Catches and logs any exceptions that occur during client communication.</exception>
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
                    case "getinactiveauctions":
                        var inactiveAuctions = await auctionService.GetInactiveAuctions();
                        return JsonSerializer.Serialize(inactiveAuctions);
                    case "getstatus":
                        if (parts.Length != 2) return "Invalid command format";
                        var status = await auctionService.GetStatus(int.Parse(parts[1]));
                        return status != null ? status : "Auction not found";
                    case "updateauction":
                        if (parts.Length != 8) return "Invalid command format";

                        var updatedAuction = new Auction
                        {
                            Id = int.Parse(parts[1]),
                            LicensePlateNumber = parts[2],
                            StartingPrice = decimal.Parse(parts[3]),
                            CurrentPrice = decimal.Parse(parts[4]),
                            StartTime = DateTime.Parse(parts[5]),
                            EndTime = DateTime.Parse(parts[6]),
                            Status = parts[7]
                        };

                        bool updateSuccess = await auctionService.UpdateAuction(updatedAuction);
                        return updateSuccess ? "Auction updated successfully" : "Failed to update auction";
                    case "deleteauction":
                        if (parts.Length != 2) return "Invalid command format";
                        bool deleteSuccess = await auctionService.DeleteAuction(int.Parse(parts[1]));
                        return deleteSuccess ? "Auction deleted successfully" : "Failed to delete auction";
                    case "addauction":
                        if (parts.Length != 7) return "Invalid command format";
                        var newAuction = new Auction
                        {
                            LicensePlateNumber = parts[1],
                            StartingPrice = decimal.Parse(parts[2]),
                            CurrentPrice = decimal.Parse(parts[3]),
                            StartTime = DateTime.Parse(parts[4]),
                            EndTime = DateTime.Parse(parts[5]),
                            Status = parts[6]
                        };

                        bool addSuccess = await auctionService.AddAuction(newAuction);
                        return addSuccess ? "Auction added successfully" : "Failed to add auction";
                    default:
                        return "Unknown command";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        static async Task UpdateWinnersAuto(AuctionService auctionService)
        {
            while (true)
            {
                try
                {
                    // Lấy các phiên đấu giá đã kết thúc
                    var inactiveAuctions = await auctionService.GetInactiveAuctions();

                    foreach (var auction in inactiveAuctions)
                    {
                        if (auction.Status != "Completed") // Chỉ xử lý nếu chưa hoàn thành
                        {
                            bool updated = await auctionService.UpdateWinner(auction.Id);
                            if (updated)
                            {
                                Console.WriteLine($"Winner updated for auction ID: {auction.Id}");
                            }
                        }
                    }

                    // Sleep for a while before next check
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating winners: {ex.Message}");
                }
            }
        }
    }
}
