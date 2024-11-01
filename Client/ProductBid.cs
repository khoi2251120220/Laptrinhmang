using Client;
using Client.Services;
using daugia;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client
{
    public partial class ProductBid : Form
    {
        private int _id;
        private AuctionClient _client;
        private System.Windows.Forms.Timer _timer;
        private Auction auctionItem;

        public ProductBid(AuctionClient client, int id)
        {
            this._client = client;
            if (_client != null && !_client.IsConnected())
            {
                HomePage homePage = new HomePage(_client, _id);
                homePage.Show();
                this.Close();
                MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
            }
            else
            {
                InitializeComponent();
                InitializeTimer();
                loadListView();
            }
            _id = id;
        }

        private async void ProductBid_Load(object sender, EventArgs e)
        {
            auctionItem = null;
            await loadData();
            await loadListHistory();
        }

        private async Task loadData()
        {
            try
            {
                List<Auction> auctions = await _client.GetActiveAuctions();
                if (auctionItem == null && auctions.Count > 0)
                {
                    auctionItem = auctions[0];
                }
                lblBienSo.Text = auctionItem.LicensePlateNumber;
                lblGiaHT.Text = auctionItem.CurrentPrice.ToString("N0") + " VNĐ";

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
                ProcessError(ex);
            }
        }

        private void loadListView()
        {
            lvHistory.Columns.Add("Giá đã đặt");
            lvHistory.Columns.Add("Thời gian");
        }

        private async Task loadListHistory()
        {
            if(auctionItem != null)
            {
                try
                {
                    lvHistory.Items.Clear();
                    List<Bid> bids = await _client.GetAuctionBids(auctionItem.Id);
                    foreach (var bid in bids)
                    {
                        var item = new ListViewItem
                        {
                            Text = bid.Amount.ToString("N0") + " VNĐ"
                        };
                        item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = bid.BidTime.ToString("HH:mm:ss dd/MM/yyyy") });
                        lvHistory.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    ProcessError(ex);
                }
            }
            lvHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void OnItemClicked(Auction auction)
        {
            auctionItem = auction;
            lblBienSo.Text = auction.LicensePlateNumber;
            lblGiaHT.Text = auction.CurrentPrice.ToString("N0") + " VNĐ";
            if (!(_timer.Enabled))
            {
                _timer.Start();
            }
            UpdateStatus();
        }

        private void TrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(_client,_id);
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
            loadListHistory();
        }

        private void UpdateStatus()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime < auctionItem.StartTime)
            {
                if(auctionItem.Status== "Cancelled")
                {
                    lblTGTieuDe.Text = "Phiên đấu giá đã bị hủy";
                    lblTG.Text = "";
                }
                else
                {
                    lblTGTieuDe.Text = "Bắt đầu sau:";
                    lblTG.Text = (auctionItem.StartTime - currentTime).ToString(@"hh\:mm\:ss");
                }
            }
            else if (currentTime >= auctionItem.EndTime)
            {
                lblTGTieuDe.Text = "Kết thúc lúc:";
                lblTG.Text = auctionItem.EndTime.ToString("HH:mm:ss dd/MM/yyyy");
                _timer.Stop(); // Dừng cập nhật khi phiên đấu giá kết thúc
            }
            else
            {
                lblTGTieuDe.Text = "Kết thúc sau:";
                lblTG.Text = (auctionItem.EndTime - currentTime).ToString(@"hh\:mm\:ss");
            }
        }

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

        private void txtGiaMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private async void btnDatGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_client.IsConnected())
                {
                    MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
                    return;
                }

                DateTime currentTime = DateTime.Now;
                if (currentTime < auctionItem.EndTime && (await _client.GetStatus(auctionItem.Id) == "Active"))
                {
                    decimal newBidAmount = decimal.Parse(txtGiaMoi.Text);
                    if (newBidAmount > auctionItem.CurrentPrice)
                    {
                        bool isSuccess = await _client.PlaceBid(auctionItem.Id, _client.CurrentUser.Id, newBidAmount);
                        if (isSuccess)
                        {
                            auctionItem.CurrentPrice = newBidAmount;
                            MessageBox.Show("Đặt giá thành công!");
                            txtGiaMoi.Clear();
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
                    MessageBox.Show("Phiên đấu giá đã kết thúc hoặc bị tạm hoãn");
                }
            }
            catch (Exception ex)
            {
                ProcessError(ex);

            }
        }
    }
}
