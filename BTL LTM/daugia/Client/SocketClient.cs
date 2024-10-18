using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class SocketClient
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public SocketClient(string ip, int port)
        {
            _client = new TcpClient(ip, port);
            _stream = _client.GetStream();
        }

        public string SendRequest(string request)
        {
            byte[] data = Encoding.ASCII.GetBytes(request);
            _stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = _stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }

        public void Close()
        {
            _stream.Close();
            _client.Close();
        }
    }

}
