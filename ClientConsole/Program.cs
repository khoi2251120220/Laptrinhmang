using Client.Services;

namespace Client
{
    class Program
    {
        private static AuctionClient _client;
        private static bool _running = true;

        static async Task Main(string[] args)
        {
            try
            {
                _client = new AuctionClient();
                Console.WriteLine("Connected to auction server!");

                while (_running)
                {
                    if (_client.CurrentUser == null)
                    {
                        await ShowLoginMenu();
                    }
                    else
                    {
                        await ShowMainMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                _client?.Dispose();
            }
        }

        static async Task ShowLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Auction System Login ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await HandleLogin();
                    break;
                case "2":
                    await HandleRegistration();
                    break;
                case "3":
                    _running = false;
                    break;
            }
        }

        static async Task ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"=== Welcome, {_client.CurrentUser.Username} ===");
            Console.WriteLine("1. View Active Auctions");
            Console.WriteLine("2. Place Bid");
            Console.WriteLine("3. Logout");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await ShowActiveAuctions();
                    break;
                case "2":
                    await HandlePlaceBid();
                    break;
                case "3":
                    _client.SetCurrentUser(null);
                    break;
                case "4":
                    _running = false;
                    break;
            }
        }

        static async Task HandleLogin()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            try
            {
                var user = await _client.Login(username, password);
                if (user != null)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static async Task HandleRegistration()
        {
            Console.Clear();
            Console.WriteLine("=== Register New User ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            try
            {
                var user = new Shared.Models.User
                {
                    Username = username,
                    Password = password,
                    Email = email
                };

                bool success = await _client.RegisterUser(user);
                if (success)
                {
                    Console.WriteLine("Registration successful! Please login.");
                }
                else
                {
                    Console.WriteLine("Registration failed. Username might be taken.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Registration error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static async Task ShowActiveAuctions()
        {
            Console.Clear();
            Console.WriteLine("=== Active Auctions ===");

            var auctions = await _client.GetActiveAuctions();
            foreach (var auction in auctions)
            {
                Console.WriteLine($"\nAuction ID: {auction.Id}");
                Console.WriteLine($"License Plate: {auction.LicensePlateNumber}");
                Console.WriteLine($"Current Price: {auction.CurrentPrice:C}");
                Console.WriteLine($"End Time: {auction.EndTime}");
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static async Task HandlePlaceBid()
        {
            Console.Clear();
            Console.WriteLine("=== Place Bid ===");

            var auctions = await _client.GetActiveAuctions();
            foreach (var auction in auctions)
            {
                Console.WriteLine($"{auction.Id}. {auction.LicensePlateNumber} - Current Price: {auction.CurrentPrice:C}");
            }

            Console.Write("\nEnter Auction ID: ");
            if (!int.TryParse(Console.ReadLine(), out int auctionId))
            {
                Console.WriteLine("Invalid auction ID");
                return;
            }

            Console.Write("Enter bid amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount");
                return;
            }

            try
            {
                bool success = await _client.PlaceBid(auctionId, _client.CurrentUser.Id, amount);
                Console.WriteLine(success ? "Bid placed successfully!" : "Failed to place bid.");

                // Show current bids after placing a bid
                var bids = await _client.GetAuctionBids(auctionId);
                Console.WriteLine("\nCurrent Bids:");
                foreach (var bid in bids)
                {
                    Console.WriteLine($"Amount: {bid.Amount:C}, Time: {bid.BidTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error placing bid: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
