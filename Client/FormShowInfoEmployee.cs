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
    public partial class FormShowInfoEmployee : Form
    {
        private AuctionClient _client;
        public FormShowInfoEmployee(AuctionClient client)
        {
            InitializeComponent();
            _client = client;
        }

        void LoadInfo()
        {
            txbId.Text = Const.NewEmploy.Id.ToString();
            txbName.Text = Const.NewEmploy.Name;
            txbAddress.Text = Const.NewEmploy.Address;
            txbSex.Text = Const.NewEmploy.Sex;
            txbPhone.Text = Const.NewEmploy.Phone.ToString();
            txbBirthday.Text = Const.NewEmploy.Birthday.ToString("dd/MM/yyyy");



        }

        private void FormShowInfoEmployee_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLND qLNDForm = new QLND(_client);
            qLNDForm.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

