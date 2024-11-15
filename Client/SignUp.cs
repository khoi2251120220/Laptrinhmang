using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.Services;
using Shared.Models;
using Server;
using Server.Data;

namespace daugia
{
    /// <summary>
    /// Form đăng ký người dùng mới cho ứng dụng đấu giá.
    /// </summary>
    public partial class SignUp : Form
    {
        private AuctionClient _client; // Client để thực hiện các yêu cầu tới server.

        /// <summary>
        /// Khởi tạo form đăng ký.
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
            _client = new AuctionClient(); // Khởi tạo client đấu giá.
        }

        // Sự kiện khi nhấn vào Label1 (hiện tại không được sử dụng).
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Sự kiện khi nhấn vào Label2 (hiện tại không được sử dụng).
        private void label2_Click(object sender, EventArgs e)
        {
        }

        // Sự kiện khi thay đổi nội dung trong TextBox1 (dùng để nhập tên người dùng).
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Sự kiện khi nhấn vào Label3 (hiện tại không được sử dụng).
        private void label3_Click(object sender, EventArgs e)
        {
        }

        // Sự kiện khi thay đổi nội dung trong TextBox2 (dùng để nhập mật khẩu).
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        // Sự kiện khi nhấn vào Label4 (hiện tại không được sử dụng).
        private void label4_Click(object sender, EventArgs e)
        {
        }

        // Sự kiện khi thay đổi nội dung trong TextBox3 (dùng để nhập email).
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Xử lý khi nhấn vào nút đăng ký.
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox.
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;

            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash mật khẩu để lưu trữ an toàn.
            string hashedPassword = UserService.HashPassword(password);
            Console.WriteLine("Hashed Password for Registration: " + hashedPassword);

            // Tạo một đối tượng User từ thông tin nhập vào.
            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            try
            {
                // Gửi yêu cầu đăng ký đến server thông qua AuctionClient.
                bool success = await _client.RegisterUser(user);

                // Kiểm tra kết quả từ server.
                if (success)
                {
                    // Thông báo đăng ký thành công và chuyển về form đăng nhập.
                    MessageBox.Show("Đăng ký thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login login = new Login();
                    login.Show(); // Hiển thị form đăng nhập.
                    this.Close(); // Đóng form đăng ký.
                }
                else
                {
                    // Thông báo lỗi khi đăng ký thất bại.
                    MessageBox.Show("Đăng ký thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi khi có ngoại lệ xảy ra trong quá trình đăng ký.
                MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
