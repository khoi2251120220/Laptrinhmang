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

namespace client
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void textBoxInfomation_TextChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {

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
