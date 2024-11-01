using Client.Services;
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
    public partial class FormAddNewEmployee : Form
    {
        private AuctionClient _client;
        public FormAddNewEmployee(AuctionClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private void FormAddNewEmployee_Load(object sender, EventArgs e)
        {
            cboSex.DataSource = Const.listSex;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(cboId.Text) ||
                string.IsNullOrWhiteSpace(cboName.Text) ||
                string.IsNullOrWhiteSpace(cboBirthday.Text) ||
                string.IsNullOrWhiteSpace(cboSex.Text) ||
                string.IsNullOrWhiteSpace(cboPhone.Text) ||
                string.IsNullOrWhiteSpace(cboAddress.Text))
            {
                MessageBox.Show("Xin hãy nhập đầy đủ các thông tin.");
                return;
            }

            int id;
            if (!int.TryParse(cboId.Text, out id))
            {
                MessageBox.Show("Dữ liệu không hợp lệ cho ID. Xin hãy nhập một số nguyên hợp lệ.");
                return;
            }

            string name = cboName.Text;
            DateTime birthday;
            if (!DateTime.TryParse(cboBirthday.Text, out birthday))
            {
                MessageBox.Show("Dữ liệu không hợp lệ cho ngày sinh. Xin hãy nhập một ngày sinh hợp lệ.");
                return;
            }

            string sex = cboSex.Text;

            int phone;
            if (!int.TryParse(cboPhone.Text, out phone))
            {
                MessageBox.Show("Dữ liệu không hợp lệ cho số điện thoại. Xin hãy nhập một số nguyên hợp lệ.");
                return;
            }

            string address = cboAddress.Text;

            // Assign values to the new employee
            Const.NewEmploy = new Employee(id, name, sex, birthday, address, phone);
            this.Close();
        }


        private void txbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLND qLND = new QLND(_client);
            this.Hide();




        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


