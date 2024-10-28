using System.Net.Sockets;
using System.Text;
using Client.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace daugia
{
    public partial class Login : Form
    {
        private AuctionClient _client;
        public Login()
        {
            InitializeComponent();
            _client = new AuctionClient();
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

            try
            {
                var user = await _client.Login(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var homePage = new HomePage(_client);
                    homePage.Show();
                    this.Hide();
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
    }
}
