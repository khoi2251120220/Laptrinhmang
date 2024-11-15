using client;
using Client.Services;
using daugia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace chứa các lớp liên quan đến giao diện người dùng của ứng dụng.
namespace Client
{
    // Class Homepage_admin kế thừa từ Form, dùng để quản lý giao diện chính của trang Admin.
    public partial class Homepage_admin : Form
    {
        // Biến để lưu trữ đối tượng AuctionClient, dùng để kết nối với dịch vụ từ phía server.
        private AuctionClient _client;

        // Constructor của form, nhận đối tượng AuctionClient làm tham số.
        public Homepage_admin(AuctionClient client)
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện của form.
            _client = client; // Gán đối tượng AuctionClient vào biến thành viên.
        }

        // Sự kiện khi nhấn vào pictureBox6, chuyển sang form quản lý người dùng (QLND).
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng form QLND và hiển thị nó.
            QLND qLNDForm = new QLND(_client);
            qLNDForm.Show(); // Hiển thị form QLND.
            this.Close(); // Đóng form hiện tại (Homepage_admin).
            _client.Dispose(); // Giải phóng tài nguyên của AuctionClient.
        }

        // Sự kiện khi nhấn vào menu "logOutToolStripMenuItem" để đăng xuất.
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận đăng xuất.
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, mở form Login và đóng form hiện tại.
                Login loginForm = new Login();
                loginForm.Show(); // Hiển thị form Login.
                this.Close(); // Đóng form Homepage_admin.
                _client.Dispose(); // Giải phóng tài nguyên của AuctionClient.
            }
        }

        // Sự kiện khi nhấn vào label10, chuyển sang form quản lý người dùng (QLND).
        private void label10_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng form QLND và hiển thị nó.
            QLND qLNDForm = new QLND(_client);
            qLNDForm.Show(); // Hiển thị form QLND.
            this.Close(); // Đóng form hiện tại (Homepage_admin).
            _client.Dispose(); // Giải phóng tài nguyên của AuctionClient.
        }

        // Sự kiện khi nhấn vào pictureBox3, kiểm tra kết nối và chuyển sang form quản lý đấu giá.
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem client có kết nối với server hay không.
            if (_client.IsConnected())
            {
                // Nếu có kết nối, mở form quản lý đấu giá (AuctionsManage).
                AuctionsManage auctionsManage = new AuctionsManage(_client);
                auctionsManage.Show(); // Hiển thị form AuctionsManage.
                this.Close(); // Đóng form hiện tại (Homepage_admin).
            }
            else
            {
                // Nếu không có kết nối, hiển thị thông báo lỗi.
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
            }
        }
    }
}
