using daugia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;

namespace client
{
    public partial class Payment : Form
    {
        private int auctionId;
        private Server.Database database = new Server.Database();
        public Payment(int auctionId)
        {
            InitializeComponent();
            this.auctionId = auctionId;
        }

        private void textBoxInfomation_TextChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            string username = "Tên người dùng";
            string? userInfo = database.LoadUserInfo(username);
            if (userInfo != null)
            {
                textBoxUserInfor.Text = userInfo;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Lấy thông tin phiên đấu giá và hiển thị 
            string auctionInfo = database.LoadAuctionInfo(username);
            textBoxAuctionInfo.Text = auctionInfo;

            decimal bidAmount = database.GetBidAmount(username, auctionId);
            textBoxAmount.Text = bidAmount.ToString("C");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!rbMomo.Checked && !rbPaypal.Checked && !rbATM.Checked && !rbVisa.Checked)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            HomePage f = new HomePage();
            f.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage f = new HomePage();
            f.Show();
        }
    }
}
