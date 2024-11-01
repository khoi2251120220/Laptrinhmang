using Client;
using Client.Services;
using daugia;
using Google.Protobuf.WellKnownTypes;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client
{
    public partial class ProductBid : Form
    {
        private AuctionClient _client;
        private System.Windows.Forms.Timer _timer;
        private Auction auctionItem = null;

        public ProductBid(AuctionClient _client)
        {
            InitializeComponent();
            InitializeTimer();
            this._client = _client;
        }

        private async void ProductBid_Load(object sender, EventArgs e)
        {
            await loadData();
            await loadListHistory();
        }

        private async Task loadData()
        {
            try
            {
                // Lấy danh sách phiên đấu giá đang hoạt động từ server
                List<Auction> auctions = await _client.GetActiveAuctions();
                if (auctionItem == null)
                {
                    auctionItem = auctions[0];
                }
                lblBienSo.Text = auctionItem.LicensePlateNumber;
                lblGiaHT.Text = lblGiaHT.Text = auctionItem.CurrentPrice.ToString("N0") + " VNĐ";

                // Xóa các điều khiển cũ trong FlowLayoutPanel trước khi thêm mới
                flowLayoutPanel1.Controls.Clear();

                // Thêm các phiên đấu giá vào FlowLayoutPanel
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

                auctions = await _client.GetInactiveAuctions();
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
                MessageBox.Show("Lỗi khi tải dữ liệu đấu giá: " + ex.Message);
            }
        }

        private async Task loadListHistory()
        {
            lvHistory.Columns.Add("Giá đã đặt");
            lvHistory.Columns.Add("Thời gian");

            try
            {
                lvHistory.Items.Clear();
                List<Bid> bids = await _client.GetAuctionBids(auctionItem.Id);
                foreach (var bid in bids)
                {
                    var item = new ListViewItem();
                    item.Text = bid.Amount.ToString("N0") + " VNĐ";
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = bid.BidTime.ToString("HH:mm:ss dd/MM/yyyy") });
                    lvHistory.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đấu giá: " + ex.Message);
            }
            lvHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void OnItemClicked(Auction auction)
        {
            auctionItem = auction;
            lblBienSo.Text = auction.LicensePlateNumber;
            lblGiaHT.Text = lblGiaHT.Text = auction.CurrentPrice.ToString("N0") + " VNĐ";
            UpdateStatus();
        }

        private void TrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(_client);
            homePage.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
            _client.Dispose();
        }

        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // Cập nhật mỗi 1 giây
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime < auctionItem.StartTime)
            {
                if (!_timer.Enabled)
                {
                    _timer.Start();
                }
                lblTGTieuDe.Text = "Bắt đầu sau:";
                lblTG.Text = (auctionItem.StartTime - currentTime).ToString(@"hh\:mm\:ss");
            }
            else if (currentTime >= auctionItem.EndTime)
            {
                lblTGTieuDe.Text = "Kết thúc lúc:";
                lblTG.Text = auctionItem.EndTime.ToString("HH:mm:ss dd/MM/yyyy");
                _timer.Stop(); // Dừng cập nhật khi phiên đấu giá kết thúc
            }
            else
            {
                if (!_timer.Enabled)
                {
                    _timer.Start();
                }
                lblTGTieuDe.Text = "Kết thúc sau:";
                lblTG.Text = (auctionItem.EndTime - currentTime).ToString(@"hh\:mm\:ss");
            }
        }

        private void txtGiaMoi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private async void btnDatGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtGiaMoi.Text, out decimal newBidAmount))
                {
                    if (newBidAmount > auctionItem.CurrentPrice)
                    {
                        bool isSuccess = await _client.PlaceBid(auctionItem.Id, _client.CurrentUser.Id, newBidAmount);
                        if (isSuccess)
                        {
                            auctionItem.CurrentPrice = newBidAmount;
                            MessageBox.Show("Đặt giá thành công!");
                            await loadData(); // Cập nhật lại dữ liệu sau khi đặt giá thành công
                        }
                        else
                        {
                            MessageBox.Show("Đặt giá thất bại. Vui lòng kiểm tra lại.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá mới phải cao hơn giá hiện tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một giá hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt giá: " + ex.Message);
            }
        }
    }
}
