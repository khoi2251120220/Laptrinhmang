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
        private System.Windows.Forms.Timer autoBidTimer;
        private Auction auctionItem;
        private int user_currentbid_id = 0;

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
            }
            _id = id;
        }

        private async void ProductBid_Load(object sender, EventArgs e)
        {
            auctionItem = null;
            await loadData();
            await loadListHistory();
            InitializeTimer();
            InitializeAutoBidTimer();
            autoBidTimer.Start();
            loadListView();
        }

        //Load dữ liệu sản phẩm
        private async Task loadData()
        {
            try
            {
                List<Auction> auctions = await _client.GetActiveAuctions();
                if (auctionItem == null && auctions.Count > 0)
                {
                    auctionItem = auctions[0];
                }
                if (auctions.Count > 0)
                {
                    lblBienSo.Text = auctionItem.LicensePlateNumber;
                    lblGiaHT.Text = auctionItem.CurrentPrice.ToString("N0") + " VNĐ";
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

                auctions = await _client.GetInactiveAuctions();
                if (auctionItem == null && auctions.Count > 0)
                {
                    auctionItem = auctions[0];
                    lblBienSo.Text = auctionItem.LicensePlateNumber;
                    lblGiaHT.Text = auctionItem.CurrentPrice.ToString("N0") + " VNĐ";
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

        private void loadListView()
        {
            lvHistory.Columns.Add("Giá đã đặt");
            lvHistory.Columns.Add("Thời gian");
        }

        //load lịch sử đấu giá
        private async Task loadListHistory()
        {
            if (auctionItem != null)
            {
                try
                {
                    lvHistory.Items.Clear();
                    List<Bid> bids = await _client.GetAuctionBids(auctionItem.Id);
                    if (bids != null && bids.Count > 0)
                    {
                        user_currentbid_id = bids[0].UserId;
                    }
                    else
                    {
                        user_currentbid_id = 0;
                    }
                    
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

        //Khi click vào phần tử trong danh sách
        private void OnItemClicked(Auction auction)
        {
            if (!auctionItem.Equals(auction))
            {
                auctionItem = auction;
                lblBienSo.Text = auction.LicensePlateNumber;
                lblGiaHT.Text = auction.CurrentPrice.ToString("N0") + " VNĐ";
                autoBidTimer?.Stop();
                chkAutoBid.Checked = false;
                txtMaxBid.Text = "";
            }
            if (!(_timer.Enabled))
            {
                _timer.Start();
            }
            UpdateStatus();
        }

        //chuyển về trang chủ
        private void TrangChuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(_client, _id);
            homePage.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
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

        //Khởi tạo timer cho chức năng đấu giá tự động
        private void InitializeAutoBidTimer()
        {
            autoBidTimer = new System.Windows.Forms.Timer();
            autoBidTimer.Interval = 1000; // Kiểm tra mỗi giây
            autoBidTimer.Tick += AutoBidTimer_Tick;
        }

        //Tự động đặt giá nếu người dùng tick vào ô checkbox
        private void AutoBidTimer_Tick(object sender, EventArgs e)
        {
            if (chkAutoBid.Checked)
            {
                try
                {
                    if (chkAutoBid.Checked && decimal.TryParse(txtMaxBid.Text, out decimal maxBid))
                    {
                        decimal currentPrice = GetCurrentPrice(); // Lấy giá hiện tại
                        decimal incrementStep = 100000; // Bước giá

                        if (user_currentbid_id != _id && (currentPrice + incrementStep <= maxBid))
                        {
                            decimal newBid = currentPrice + incrementStep;
                            PlaceBid(newBid);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đặt giá tự động: {ex.Message}");
                    autoBidTimer.Stop();
                }

            }
        }

        private decimal GetCurrentPrice()
        {
            // Hàm giả lập để lấy giá hiện tại từ `auctionItem`
            return auctionItem != null ? auctionItem.CurrentPrice : 0;
        }

        //Đặt giá tự động
        private void PlaceBid(decimal amount)
        {
            txtGiaMoi.Text = amount.ToString();
            btnDatGia.PerformClick(); // Giả lập nhấn nút "Đặt Giá"
        }

        //Cập nhật trạng thái đấu giá
        private void UpdateStatus()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime < auctionItem.StartTime)
            {
                if (auctionItem.Status == "Cancelled")
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

        private void txtGiaMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập số từ bàn phím
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private async void btnDatGia_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra kết nối
                if (!_client.IsConnected())
                {
                    MessageBox.Show("Mất kết nối với server. Vui lòng kiểm tra lại.");
                    return;
                }

                DateTime currentTime = DateTime.Now;
                //Kiểm tra điều kiện đặt giá
                if (currentTime < auctionItem.EndTime && (await _client.GetStatus(auctionItem.Id) == "Active"))
                {
                    decimal newBidAmount = decimal.Parse(txtGiaMoi.Text);
                    if (currentTime >= auctionItem.StartTime && newBidAmount > auctionItem.CurrentPrice)
                    {
                        bool isSuccess = await _client.PlaceBid(auctionItem.Id, _client.CurrentUser.Id, newBidAmount);
                        if (isSuccess)
                        {
                            auctionItem.CurrentPrice = newBidAmount;
                            MessageForm.Show($"Đã đặt giá: {newBidAmount:N0} VNĐ", "Thông báo", 3000);
                          
                            txtGiaMoi.Clear();
                            await loadData(); // Cập nhật lại dữ liệu sau khi đặt giá thành công
                        }
                        else
                        {
                            MessageBox.Show("Đặt giá thất bại. Vui lòng kiểm tra lại.");
                        }
                    }
                    else if(currentTime < auctionItem.StartTime)
                    {
                        MessageBox.Show("Phiên đấu giá chưa diễn ra");
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

        private void chkAutoBid_CheckedChanged(object sender, EventArgs e)
        {
            txtMaxBid.Enabled = chkAutoBid.Checked; // Bật/Tắt TextBox giá tối đa
            if (!chkAutoBid.Checked)
            {
                txtMaxBid.Text = ""; // Xóa giá trị nếu hủy kích hoạt
            }
            else
            {
                autoBidTimer?.Start();
            }
        }
    }
}
