using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Server.Services;

namespace Server
{
    public class SocketServer
    {
        private TcpListener _server;
        private AuctionService _auctionService;
        private bool _isRunning = false;

        public SocketServer(string ip, int port, AuctionService auctionService)
        {
            IPAddress localAddr = IPAddress.Parse(ip);
            _server = new TcpListener(localAddr, port);
            _auctionService = auctionService;
        }

        public void Start()
        {
            _server.Start();
            _isRunning = true;
            Console.WriteLine("Server started. Waiting for connections...");

            while (_isRunning)
            {
                TcpClient client = _server.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.Start(client);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                    break;

                string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {data}");

                // Process the received data
                string response = ProcessRequest(data);

                byte[] msg = Encoding.ASCII.GetBytes(response);
                stream.Write(msg, 0, msg.Length);
            }

            client.Close();
        }

        private string ProcessRequest(string request)
        {
            // Implement your request processing logic here
            // For now, let's just return all auctions
            var auctions = _auctionService.GetAllAuctions();
            return System.Text.Json.JsonSerializer.Serialize(auctions);
        }
    }
}
