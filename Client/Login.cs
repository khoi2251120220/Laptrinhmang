using System.Net.Sockets;
using System.Text;
using Client.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Server;
using Server.Data;
using Client;
namespace daugia
{
    public partial class Login : Form
    {
        private int _id;
        private AuctionClient _client;
        public Login()
        {
            InitializeComponent();
            _client = new AuctionClient();
        }
        public Login(AuctionClient _client, int id)
        {
            InitializeComponent();
            _id = id;
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
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string hashedPassword = UserService.HashPassword(password);
            Console.WriteLine("Hashed Password for Login: " + hashedPassword);
            try
            {
                var user = await _client.Login(username, hashedPassword);
                if (user != null)
                {
                    _id = user.Id;
                    if (user.Role == "admin") // Giả sử bạn có thuộc tính Role trong đối tượng user
                    {
                        MessageBox.Show("Login successful as Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var adminPage = new Homepage_admin(_client); // Chuyển đến trang admin
                        adminPage.Show();
                    }
                    else
                    {

                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var homePage = new HomePage(_client, _id);
                        homePage.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Mật khẩu đã được reset thành: 123a", "Reset Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
