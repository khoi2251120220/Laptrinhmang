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
        private int _id;
        private AuctionClient _client;
        public answer(AuctionClient _client, int id)
        {
            InitializeComponent();
            this._client = _client;
            _id = id;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form Homepage
            HomePage homepageForm = new HomePage(_client, _id);

            // Hiển thị form Homepage
            homepageForm.Show();

            // Đóng form hiện tại (giả sử form hiện tại là MainForm)
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}
