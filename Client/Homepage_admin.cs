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

namespace Client
{
    public partial class Homepage_admin : Form
    {
        private AuctionClient _client;
        public Homepage_admin(AuctionClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            {
                QLND qLNDForm = new QLND(_client);
                qLNDForm.Show();
                this.Close();
                _client.Dispose();

            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
                _client.Dispose();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            QLND qLNDForm = new QLND(_client);
            qLNDForm.Show();
            this.Close();
            _client.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (_client.IsConnected())
            {
                AuctionsManage auctionsManage = new AuctionsManage(_client);
                auctionsManage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
            }
        }
    }
}

