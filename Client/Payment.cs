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
using client;
using Client;
using Client.Services;
using Server.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class Payment : Form
    {
        private int _id;
        private AuctionClient _client;
        public Payment(AuctionClient _client, int id)
        {
            InitializeComponent();
            _id = id;

        }

        private void textBoxInfomation_TextChanged(object sender, EventArgs e)
        {

        }
        //Load dữ liệu lên trang thanh toán 

        private async void Payment_Load(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext();
            string username = await dbContext.GetUsernameById(_id);

            if (!string.IsNullOrEmpty(username))
            {
                textBoxUserName.Text = username;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Lấy thông tin biển số và tổng số tiền thanh toán
            var (licensePlateNumber, totalAmount) = await dbContext.GetAuctionDetailsAndTotalAmount(_id);


            textBoxInfomation.Text = licensePlateNumber;
            textBoxTotalAmount.Text = totalAmount.ToString("C2");
        }
        //Kiểm tra thông tin khi nhấn thanh toán 

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (!radioButtonMomo.Checked && !radioButtonPaypal.Checked && !radioButtonATM.Checked && !radioButtonVisa.Checked)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var paymentMethod = GetSelectedPaymentMethod();
            var dbContext = new DatabaseContext();
            string status = "Thành công";

            // Kiểm tra các điều kiện cho thanh toán
            if (string.IsNullOrEmpty(textBoxUserName.Text) ||
                string.IsNullOrEmpty(textBoxInfomation.Text) ||
                decimal.TryParse(textBoxTotalAmount.Text, out decimal totalAmount) && totalAmount == 0)
            {
                MessageBox.Show("Thanh toán thất bại! Kiểm tra lại thông tin thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lưu lịch sử thanh toán
            await dbContext.SavePaymentHistory(textBoxUserName.Text, textBoxInfomation.Text, totalAmount, paymentMethod, status, _id, await GetAuctionIdByUserId(_id));

            HomePage homePage = new HomePage(_client, _id);
            homePage.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(_client, _id);
            homePage.Show();
            this.Hide();
        }
        private string GetSelectedPaymentMethod()
        {
            if (radioButtonMomo.Checked) return "Momo";
            if (radioButtonPaypal.Checked) return "Paypal";
            if (radioButtonATM.Checked) return "ATM";
            if (radioButtonVisa.Checked) return "Visa";
            return "Unknown";
        }
        private async Task<int> GetAuctionIdByUserId(int id)
        {
            var dbContext = new DatabaseContext();
            return await dbContext.GetAuctionIdByUserId(id);
        }
    }
}
