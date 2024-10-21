using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace daugia
{
    public partial class SignUp : Form
    {
   

        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 9999))
                {
                    NetworkStream stream = client.GetStream();

                    string signUpInfo = $"register:{userName}:{password}:{email}";
                    byte[] dataToSend = Encoding.UTF8.GetBytes(signUpInfo);
                    stream.Write(dataToSend, 0, dataToSend.Length);

                    byte[] dataToReceive = new byte[1024];
                    int bytesRead = stream.Read(dataToReceive, 0, dataToReceive.Length);
                    string response = Encoding.UTF8.GetString(dataToReceive, 0, bytesRead);

                    if (response == "Registration successful")
                    {
                        MessageBox.Show("Đăng ký thành công!");
                        this.Hide();
                        HomePage homePage = new HomePage();
                        homePage.Show();
                    }
                    else
                    {
                        MessageBox.Show(response); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
