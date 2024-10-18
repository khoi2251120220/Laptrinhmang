using System;
using System.Collections.Generic;
using System.Text.Json;
using Shared.Models;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient client = new SocketClient("127.0.0.1", 8888);

            Console.WriteLine("Connected to server. Requesting auctions...");

            string response = client.SendRequest("GET_AUCTIONS");
            List<Auction> auctions = JsonSerializer.Deserialize<List<Auction>>(response);

            Console.WriteLine("Current auctions:");
            foreach (var auction in auctions)
            {
                Console.WriteLine($"{auction.Id} | {auction.PlateNumber} | {auction.CurrentPrice} | {auction.Status} | {auction.HighestBidder}");
            }

            client.Close();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
