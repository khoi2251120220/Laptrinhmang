using Client.Services;
using daugia;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class AuctionsManage : Form
    {
        private int _id;
        private AuctionClient _client;
        private System.Windows.Forms.Timer _timer;
        private Auction auctionItem;
        public AuctionsManage(AuctionClient _client)
        {
            this._client = _client;
            if (_client != null && !_client.IsConnected())
            {
                Homepage_admin homepage_Admin = new Homepage_admin(_client);
                homepage_Admin.Show();
                this.Close();
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
            }
            else
            {
                InitializeComponent();
            }
        }

        private async void AuctionsManage_Load(object sender, EventArgs e)
        {
            auctionItem = null;
            await loadData();
        }

        //Load dữ liệu
        private async Task loadData()
        {
            try
            {
                //Lấy phiên đấu giá đang hoạt động
                List<Auction> auctions = await _client.GetActiveAuctions();
                if (auctionItem == null && auctions.Count > 0)
                {
                    auctionItem = auctions[0];
                }
                if(auctions.Count > 0)
                {
                    txtBienso.Text = auctionItem.LicensePlateNumber;
                    txtGiaBD.Text = auctionItem.StartingPrice.ToString();
                    dtbStart.Value = auctionItem.StartTime;
                    dtbKetThuc.Value = auctionItem.EndTime;
                    cbbStatus.SelectedItem = auctionItem.Status;
                }

                flowLayoutPanel1.Controls.Clear();

                foreach (var auction in auctions)
                {
                    var ucProduct = new UCProduct
                    {
                        LicensePlateNumber = auction.LicensePlateNumber,
                        CurrentPrice = auction.CurrentPrice,
                        StartTime = auction.StartTime,
                        EndTime = auction.EndTime,
                        Status = auction.Status
                    };

                    ucProduct.Clicked += (s, e) => OnItemClicked(auction);
                    flowLayoutPanel1.Controls.Add(ucProduct);
                }

                //Lấy những phiên đấu giá còn lại
                auctions = await _client.GetInactiveAuctions();
                if (auctionItem == null && auctions.Count > 0)
                {
                    auctionItem = auctions[0];
                    txtBienso.Text = auctionItem.LicensePlateNumber;
                    txtGiaBD.Text = auctionItem.StartingPrice.ToString();
                    dtbStart.Value = auctionItem.StartTime;
                    dtbKetThuc.Value = auctionItem.EndTime;
                    cbbStatus.SelectedItem = auctionItem.Status;
                }
                foreach (var auction in auctions)
                {
                    var ucProduct = new UCProduct
                    {
                        LicensePlateNumber = auction.LicensePlateNumber,
                        CurrentPrice = auction.CurrentPrice,
                        StartTime = auction.StartTime,
                        EndTime = auction.EndTime,
                        Status = auction.Status
                    };

                    ucProduct.Clicked += (s, e) => OnItemClicked(auction);
                    flowLayoutPanel1.Controls.Add(ucProduct);
                }
            }
            catch (Exception ex)
            {
                ProcessError(ex);
            }
        }

        private void OnItemClicked(Auction auction)
        {
            auctionItem = auction;
            txtBienso.Text = auction.LicensePlateNumber;
            txtGiaBD.Text = auction.StartingPrice.ToString();
            dtbStart.Value = auction.StartTime;
            dtbKetThuc.Value = auction.EndTime;
            cbbStatus.SelectedItem = auction.Status;
        }

        private void TrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepage_admin homepage_Admin = new Homepage_admin(_client);
            homepage_Admin.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
            _client.Dispose();
        }


        //Xử lý lỗi
        private void ProcessError(Exception ex)
        {
            if (!_client.IsConnected())
            {
                _timer?.Stop();
                _timer?.Dispose();
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
            }
            else
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message);
            }
        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (auctionItem == null)
            {
                MessageBox.Show("Chưa chọn phiên đấu giá để cập nhật.");
                return;
            }

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtBienso.Text) ||
                !decimal.TryParse(txtGiaBD.Text, out decimal startingPrice) ||
                dtbStart.Value >= dtbKetThuc.Value)
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ.");
                return;
            }

            // Cập nhật giá trị mới
            auctionItem.LicensePlateNumber = txtBienso.Text;
            auctionItem.StartingPrice = startingPrice;
            auctionItem.StartTime = dtbStart.Value;
            auctionItem.EndTime = dtbKetThuc.Value;
            auctionItem.Status = cbbStatus.SelectedItem.ToString();

            bool updateSuccess = await _client.UpdateAuction(auctionItem);
            if (updateSuccess)
            {
                MessageBox.Show("Cập nhật thành công!");
                await loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.");
            }
        }

        //Xóa phiên đấu giá
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (auctionItem != null)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa cuộc đấu giá này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await _client.DeleteAuction(auctionItem.Id);
                    if (success)
                    {
                        MessageBox.Show("Xóa cuộc đấu giá thành công.");
                        await loadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa cuộc đấu giá thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có cuộc đấu giá nào được chọn để xóa.");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            using (var addAuctionForm = new AddAuctions(_client))
            {
                if (addAuctionForm.ShowDialog() == DialogResult.OK)
                {
                    await loadData();
                }
            }
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void TrangChuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Homepage_admin homepage_Admin = new Homepage_admin(_client);
            homepage_Admin.Show();
            this.Close();
        }
    }
}
