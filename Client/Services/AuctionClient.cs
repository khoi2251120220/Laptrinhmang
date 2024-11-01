using System.Net.Sockets;
using System.Text.Json;
using Shared.Models;
using Shared.Interfaces;
using System.Threading;

namespace Client.Services
{
    public class AuctionClient : IAuctionService, IDisposable
    {
        private readonly TcpClient _client;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private User _currentUser;
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        public AuctionClient(string serverIp = "127.0.0.1", int port = 5000)
        {
            _client = new TcpClient(serverIp, port);
            var stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };
        }

        // Implement IAuctionService interface methods
        public async Task<List<Auction>> GetActiveAuctions()
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync("getauctions");
                var response = await _reader.ReadLineAsync();
                return JsonSerializer.Deserialize<List<Auction>>(response);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<List<Auction>> GetInactiveAuctions()
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync("getinactiveauctions");
                var response = await _reader.ReadLineAsync();
                return JsonSerializer.Deserialize<List<Auction>>(response);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<bool> PlaceBid(int auctionId, int userId, decimal amount)
        {
            await _lock.WaitAsync();
            try
            {
                if (_currentUser == null || _currentUser.Id != userId)
                    throw new InvalidOperationException("Must be logged in with correct user to place bid");

                await _writer.WriteLineAsync($"placebid|{auctionId}|{userId}|{amount}");
                var response = await _reader.ReadLineAsync();
                return response == "Bid placed successfully";
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<List<Bid>> GetAuctionBids(int auctionId)
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync($"getbids|{auctionId}");
                var response = await _reader.ReadLineAsync();
                return JsonSerializer.Deserialize<List<Bid>>(response);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync($"register|{user.Username}|{user.Password}|{user.Email}");
                var response = await _reader.ReadLineAsync();
                return response == "Registration successful";
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<User> Login(string username, string password)
        {
            await _lock.WaitAsync();
            try
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
            finally
            {
                _lock.Release();
            }
        }

        public async Task<string> GetStatus(int auctionId)
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync($"getstatus|{auctionId}");
                var response = await _reader.ReadLineAsync();
                return response ?? "Auction not found";
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<bool> UpdateAuction(Auction auction)
        {
            await _lock.WaitAsync();
            try
            {
                string auctionData = $"{auction.Id}|{auction.LicensePlateNumber}|{auction.StartingPrice}|{auction.CurrentPrice}|{auction.StartTime}|{auction.EndTime}|{auction.Status}";
                await _writer.WriteLineAsync($"updateauction|{auctionData}");
                var response = await _reader.ReadLineAsync();
                return response == "Auction updated successfully";
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<bool> DeleteAuction(int auctionId)
        {
            await _lock.WaitAsync();
            try
            {
                await _writer.WriteLineAsync($"deleteauction|{auctionId}");
                var response = await _reader.ReadLineAsync();
                return response == "Auction deleted successfully";
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<bool> AddAuction(Auction newAuction)
        {
            await _lock.WaitAsync();
            try
            {
                string auctionData = $"{newAuction.LicensePlateNumber}|{newAuction.StartingPrice}|{newAuction.CurrentPrice}|{newAuction.StartTime}|{newAuction.EndTime}|{newAuction.Status}";
                await _writer.WriteLineAsync($"addauction|{auctionData}");
                var response = await _reader.ReadLineAsync();
                return response == "Auction added successfully";
            }
            finally
            {
                _lock.Release();
            }
        }


        public bool IsConnected()
        {
            try
            {
                return _client != null && _client.Client.Connected;
            }
            catch
            {
                return false;
            }
        }

        public User CurrentUser => _currentUser;

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public void Dispose()
        {
            _lock.Dispose();
            _reader?.Dispose();
            _writer?.Dispose();
            _client?.Dispose();
        }

        public void Close()
        {
            Dispose();
        }
    }
}
