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
    public partial class HomePage : Form
    {
        private AuctionClient _client;
        public HomePage(AuctionClient _client)
        {
            InitializeComponent();
            this._client = _client;
        }

        private void đánklsanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đấuGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            ProductBid productBidForm = new ProductBid(_client);
            productBidForm.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ProductBid productBidForm = new ProductBid(_client);
            productBidForm.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            answer answerForm = new answer(_client);
            answerForm.Show();
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form About
            About aboutForm = new About(_client);

            // Hiển thị form About dưới dạng một hộp thoại
            aboutForm.Show();
            this.Close();
        }

        private void trangChủToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Tạo một instance của form Homepage
            HomePage homepageForm = new HomePage(_client);

            // Hiển thị form Homepage
            homepageForm.Show();

            // Đóng form hiện tại (giả sử form hiện tại là MainForm)
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form About
            About aboutForm = new About(_client);

            // Hiển thị form About dưới dạng một hộp thoại
            aboutForm.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            answer answerForm = new answer(_client);
            answerForm.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}
