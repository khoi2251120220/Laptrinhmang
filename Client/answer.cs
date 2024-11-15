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

namespace Client
{
    public partial class answer : Form
    {
        private int _id; // Biến lưu trữ ID người dùng
        private AuctionClient _client; // Biến lưu trữ đối tượng kết nối với server (AuctionClient)

        // Constructor nhận vào client và ID người dùng
        public answer(AuctionClient _client, int id)
        {
            InitializeComponent(); // Khởi tạo các thành phần của form
            this._client = _client; // Gán đối tượng client
            _id = id; // Gán ID người dùng
        }

        // Sự kiện khi nhấn vào nhãn (label4), hiện tại không làm gì
        private void label4_Click(object sender, EventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi văn bản trong TextBox 3 thay đổi
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi nhấn vào mục "Trang chủ" trong menu
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form Homepage và truyền vào đối tượng _client và _id
            HomePage homepageForm = new HomePage(_client, _id);

            // Hiển thị form Homepage
            homepageForm.Show();

            // Đóng form hiện tại (form 'answer')
            this.Close();
        }

        // Sự kiện khi văn bản trong TextBox 2 thay đổi
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi có một phần của panel được vẽ lại
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Có thể thêm xử lý tại đây nếu cần thiết
        }

        // Sự kiện khi nhấn vào mục "Đăng xuất" trong menu
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo form Login mới để người dùng có thể đăng nhập lại
            Login loginForm = new Login();
            loginForm.Show(); // Hiển thị form đăng nhập
            this.Close(); // Đóng form hiện tại (form 'answer')
        }
    }
}
