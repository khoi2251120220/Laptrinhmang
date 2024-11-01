using System.Net.Sockets;
using System.Text.Json;
using Shared.Models;
using Shared.Interfaces;

namespace Client.Services
{
    public class AuctionClient : IAuctionService, IDisposable
    {
        private readonly TcpClient _client;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private User _currentUser;

        public AuctionClient(string serverIp = "127.0.0.1", int port = 5000)
        {
            _client = new TcpClient(serverIp, port);
            var stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream);
            _writer.AutoFlush = true;
        }

        // Implement IAuctionService interface methods
        public async Task<List<Auction>> GetActiveAuctions()
        {
            await _writer.WriteLineAsync("getauctions");
            var response = await _reader.ReadLineAsync();
            return JsonSerializer.Deserialize<List<Auction>>(response);
        }
        public async Task<List<Auction>> GetInactiveAuctions()
        {
            await _writer.WriteLineAsync("getinactiveauctions");
            var response = await _reader.ReadLineAsync();
            return JsonSerializer.Deserialize<List<Auction>>(response);
        }

        public async Task<bool> PlaceBid(int auctionId, int userId, decimal amount)
        {
            if (_currentUser == null || _currentUser.Id != userId)
                throw new InvalidOperationException("Must be logged in with correct user to place bid");

            await _writer.WriteLineAsync($"placebid|{auctionId}|{userId}|{amount}");
            var response = await _reader.ReadLineAsync();
            return response == "Bid placed successfully";
        }

        public async Task<List<Bid>> GetAuctionBids(int auctionId)
        {
            await _writer.WriteLineAsync($"getbids|{auctionId}");
            var response = await _reader.ReadLineAsync();
            return JsonSerializer.Deserialize<List<Bid>>(response);
        }

        public async Task<bool> RegisterUser(User user)
        {
            await _writer.WriteLineAsync($"register|{user.Username}|{user.Password}|{user.Email}");
            var response = await _reader.ReadLineAsync();
            return response == "Registration successful";
        }

        public async Task<User> Login(string username, string password)
        {
            await _writer.WriteLineAsync($"login|{username}|{password}");
            var response = await _reader.ReadLineAsync();

            try
            {
                var user = JsonSerializer.Deserialize<User>(response);
                if (user != null)
                {
                    _currentUser = user;
                    return user;
                }
            }
            catch
            {
                // If response is not a valid user JSON
            }

            return null;
        }

        public User CurrentUser => _currentUser;

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public void Dispose()
        {
            _reader?.Dispose();
            _writer?.Dispose();
            _client?.Dispose();
        }

        // Alias for Close() to maintain backwards compatibility
        public void Close()
        {
            Dispose();
        }
    }
}
