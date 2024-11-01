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
        private int _id;
        private AuctionClient client;
        public About(AuctionClient client, int id)
        {
            InitializeComponent();
            _id = id;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form Homepage
            HomePage homepageForm = new HomePage(client, _id);

            // Hiển thị form Homepage
            homepageForm.Show();

            // Đóng form hiện tại (giả sử form hiện tại là MainForm)
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
