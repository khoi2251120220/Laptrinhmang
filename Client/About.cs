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
using Client;
using Client.Services;

namespace Client
{
    public partial class About : Form
    {
        private int _id; // Biến lưu trữ ID người dùng
        private AuctionClient client; // Biến lưu trữ đối tượng kết nối với server (AuctionClient)

        // Constructor nhận vào client và ID người dùng
        public About(AuctionClient client, int id)
        {
            InitializeComponent(); // Khởi tạo các thành phần của form
            this.client = client; // Gán đối tượng client
            _id = id; // Gán ID người dùng
        }

        // Sự kiện khi nhấn vào một mục trong menu strip, không sử dụng ở đây
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi nhấn vào mục "Trang chủ" trong menu
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form Homepage và truyền vào đối tượng client và _id
            HomePage homepageForm = new HomePage(client, _id);

            // Hiển thị form Homepage
            homepageForm.Show();

            // Đóng form hiện tại (form 'About')
            this.Close();
        }

        // Sự kiện khi văn bản trong TextBox 1 thay đổi, hiện tại không làm gì
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi nhấn vào mục "Đăng xuất" trong menu
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo form Login mới để người dùng có thể đăng nhập lại
            Login loginForm = new Login();
            loginForm.Show(); // Hiển thị form đăng nhập
            this.Close(); // Đóng form hiện tại (form 'About')
        }
    }
}
