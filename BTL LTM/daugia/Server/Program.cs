using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace ConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# MySQL");
            string connStr = "server=localhost;user=root;database=auction_db;port=3306;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}