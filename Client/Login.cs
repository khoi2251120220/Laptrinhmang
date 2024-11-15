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
        // Biến lưu trữ ID người dùng hiện tại
        private int _id;

        // Đối tượng AuctionClient để giao tiếp với server
        private AuctionClient _client;

        // Constructor mặc định khởi tạo form login và tạo mới AuctionClient
        public Login()
        {
            InitializeComponent();
            _client = new AuctionClient();
        }

        // Constructor nhận đối tượng AuctionClient và ID để khởi tạo
        public Login(AuctionClient _client, int id)
        {
            InitializeComponent();
            _id = id;
            this._client = _client;
        }

        // Sự kiện khi click vào label1 (không xử lý chức năng gì hiện tại)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện khi thay đổi nội dung của textbox1 (không xử lý chức năng gì hiện tại)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Sự kiện khi click vào nút "Đăng ký", mở form SignUp
        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show(); // Hiển thị form đăng ký
            this.Close();      // Đóng form đăng nhập
        }

        // Sự kiện khi thay đổi nội dung của textbox2 (không xử lý chức năng gì hiện tại)
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Sự kiện khi click vào nút "Đăng nhập", thực hiện xử lý đăng nhập
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mã hóa mật khẩu người dùng nhập
            string hashedPassword = UserService.HashPassword(password);
            Console.WriteLine("Hashed Password for Login: " + hashedPassword);

            try
            {
                // Gửi yêu cầu đăng nhập đến server
                var user = await _client.Login(username, hashedPassword);

                if (user != null) // Kiểm tra nếu đăng nhập thành công
                {
                    _id = user.Id; // Lưu ID người dùng

                    // Kiểm tra vai trò của người dùng (admin hoặc user)
                    if (user.Role == "admin") // Giả sử có thuộc tính Role trong user
                    {
                        MessageBox.Show("Login successful as Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var adminPage = new Homepage_admin(_client); // Chuyển đến trang admin
                        adminPage.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var homePage = new HomePage(_client, _id); // Chuyển đến trang người dùng
                        homePage.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                }
                else
                {
                    // Thông báo nếu tên đăng nhập hoặc mật khẩu không đúng
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu không thể đăng nhập
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi click vào link reset mật khẩu
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Mật khẩu đã được reset thành: 123a", "Reset Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sự kiện khi click vào pictureBox1 (không xử lý chức năng gì hiện tại)
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện khi form Login được load (không xử lý chức năng gì hiện tại)
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
