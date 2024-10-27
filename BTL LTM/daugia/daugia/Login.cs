using System.Net.Sockets;
using System.Text;
using client;

namespace daugia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            string hashedPassword = UserService.HashPassword(password);
            Console.WriteLine("Hashed Password for Login: " + hashedPassword);
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 9999))
                {
                    NetworkStream stream = client.GetStream();

                    string loginInfo = $"{userName}:{hashedPassword}";
                    byte[] dataToSend = Encoding.UTF8.GetBytes(loginInfo);
                    stream.Write(dataToSend, 0, dataToSend.Length);

                    byte[] dataToReceive = new byte[1024];
                    int bytesRead = stream.Read(dataToReceive, 0, dataToReceive.Length);
                    string response = Encoding.UTF8.GetString(dataToReceive, 0, bytesRead);

                    if (response == "Login successful")
                    {
                        MessageBox.Show("Login successful!");
                        HomePage homePage = new HomePage();
                        homePage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Mật khẩu đã được reset thành: 123a", "Reset Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
