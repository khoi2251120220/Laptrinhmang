using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client;
using Client;
using Client.Services;

namespace daugia
{
    /// <summary>
    /// Lớp đại diện cho form Trang chủ của ứng dụng đấu giá.
    /// </summary>
    public partial class HomePage : Form
    {
        private int _id; // ID của người dùng hiện tại.
        private AuctionClient _client; // Client để giao tiếp với server đấu giá.

        /// <summary>
        /// Khởi tạo form Trang chủ.
        /// </summary>
        /// <param name="_client">Đối tượng AuctionClient để kết nối tới server.</param>
        /// <param name="id">ID của người dùng hiện tại.</param>
        public HomePage(AuctionClient _client, int id)
        {
            InitializeComponent();
            this._client = _client;
            _id = id;
        }

        // Sự kiện nhấn vào các label hoặc panel (hiện không sử dụng).
        private void đánklsanToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel6_Paint(object sender, PaintEventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void đấuGiáToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel2_Paint_1(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void HomePage_Load(object sender, EventArgs e) { }
        private void panel8_Paint(object sender, PaintEventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void label22_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Chuyển đến form thanh toán khi nhấn vào label liên quan.
        /// </summary>
        private void label7_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment(_client, _id);
            paymentForm.Show(); // Hiển thị form thanh toán.
            this.Hide(); // Ẩn form hiện tại.
        }

        /// <summary>
        /// Chuyển đến form đấu giá khi nhấn vào Label11 hoặc PictureBox3.
        /// </summary>
        private void label11_Click(object sender, EventArgs e)
        {
            if (_client.IsConnected()) // Kiểm tra kết nối tới server.
            {
                ProductBid productBidForm = new ProductBid(_client, _id);
                productBidForm.Show();
                this.Close(); // Đóng form hiện tại.
            }
            else
            {
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại."); // Hiển thị lỗi nếu mất kết nối.
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label11_Click(sender, e); // Tái sử dụng sự kiện của Label11.
        }

        /// <summary>
        /// Chuyển đến form hỏi đáp khi nhấn vào PictureBox7 hoặc Label13.
        /// </summary>
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            answer answerForm = new answer(_client, _id);
            answerForm.Show();
            this.Close();
        }
        private void label13_Click(object sender, EventArgs e)
        {
            pictureBox7_Click(sender, e); // Tái sử dụng sự kiện của PictureBox7.
        }

        /// <summary>
        /// Chuyển đến form Giới thiệu (About) khi nhấn vào Label9 hoặc PictureBox8.
        /// </summary>
        private void label9_Click(object sender, EventArgs e)
        {
            About aboutForm = new About(_client, _id);
            aboutForm.Show();
            this.Close();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label9_Click(sender, e); // Tái sử dụng sự kiện của Label9.
        }

        /// <summary>
        /// Chuyển đến trang chủ khi nhấn vào Menu "Trang Chủ".
        /// </summary>
        private void trangChủToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HomePage homepageForm = new HomePage(_client, _id);
            homepageForm.Show();
            this.Close();
        }

        /// <summary>
        /// Đăng xuất và chuyển đến form Đăng nhập.
        /// </summary>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        /// <summary>
        /// Chuyển đến form thông tin tài khoản.
        /// </summary>
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationUser informationUserForm = new InformationUser(_id);
            informationUserForm.Show();
            this.Hide(); // Ẩn form hiện tại.
        }
    }
}
