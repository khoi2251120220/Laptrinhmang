using Client.Services;
using Microsoft.Extensions.Logging;
using Shared.Models;
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
    public partial class AddAuctions : Form
    {
        private AuctionClient _client;

        public AddAuctions(AuctionClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin và thêm phiên đấu giá
            if (string.IsNullOrWhiteSpace(txtBienso.Text) ||
                !decimal.TryParse(txtGiaBD.Text, out decimal startingPrice) ||
                dtbStart.Value >= dtbKetThuc.Value)
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ.");
                return;
            }

            var newAuction = new Auction
            {
                LicensePlateNumber = txtBienso.Text,
                StartingPrice = startingPrice,
                CurrentPrice = startingPrice,
                StartTime = dtbStart.Value,
                EndTime = dtbKetThuc.Value,
                Status = cbbStatus.SelectedItem.ToString()
            };

            bool success = await _client.AddAuction(newAuction);
            if (success)
            {
                MessageBox.Show("Thêm phiên đấu giá thành công!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thêm phiên đấu giá thất bại. Vui lòng thử lại.");
            }
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
