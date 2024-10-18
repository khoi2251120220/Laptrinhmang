using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            try
            {
                TcpClient client = new TcpClient();

                client.Connect("127.0.0.1", PORT_NUMBER);
                NetworkStream stream = client.GetStream();

                Console.WriteLine("Đã kết nối với Server.");
                Console.Write("Tên của bạn là gì? ");

                string str = Console.ReadLine();

                byte[] data = Encoding.UTF8.GetBytes(str);

                stream.Write(data, 0, data.Length);

                data = new byte[BUFFER_SIZE];
                stream.Read(data, 0, BUFFER_SIZE);

                Console.WriteLine(Encoding.UTF8.GetString(data));

                stream.Close();
                client.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex);
            }

            Console.Read();
        }
    }
}
