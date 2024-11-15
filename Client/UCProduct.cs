using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client
{
    public partial class UCProduct : UserControl
    {
        private System.Windows.Forms.Timer _timer;
        public event EventHandler Clicked;

        public UCProduct()
        {
            InitializeComponent();
            InitializeTimer();
            this.Click += UCProduct_Click;
            lblBienso.Click += UCProduct_Click;
            label2.Click += UCProduct_Click;
            lblGiaHT.Click += UCProduct_Click;
            label3.Click += UCProduct_Click;
            lblTrangthai.Click += UCProduct_Click;
            lblDemnguoc.Click += UCProduct_Click;
            panel1.Click += UCProduct_Click;
        }

        #region Properties

        private string _licensePlateNumber;
        private decimal _startingPrice;
        private decimal _currentPrice;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _status;

        [Category("Data")]
        public string LicensePlateNumber
        {
            get { return _licensePlateNumber; }
            set { _licensePlateNumber = value; lblBienso.Text = value; }
        }

        [Category("Data")]
        public decimal CurrentPrice
        {
            get { return _currentPrice; }
            set { _currentPrice = value; lblGiaHT.Text = value.ToString("N0") + " VNĐ"; }
        }

        [Category("Data")]
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value;}
        }

        [Category("Data")]
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value;}
        }

        [Category("Data")]
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                UpdateStatus();
            }
        }

        #endregion

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

        //Tự động cập nhật trạng thái
        private void UpdateStatus()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime < _startTime)
            {
                if(_status== "Cancelled")
                {
                    lblTrangthai.Text = "Phiên đấu giá đã bị hủy";
                    lblDemnguoc.Text = "";
                }
                else
                {
                    lblTrangthai.Text = "Phiên đấu giá sắp diễn ra";
                    lblDemnguoc.Text = "Bắt đầu sau: " + (_startTime - currentTime).ToString(@"hh\:mm\:ss");
                }
                
            }
            else if (currentTime >= _endTime)
            {
                lblTrangthai.Text = "Đã kết thúc";
                lblDemnguoc.Text = "Kết thúc lúc: " + _endTime.ToString("HH:mm:ss dd/MM/yyyy");
                _timer.Stop(); // Dừng cập nhật khi phiên đấu giá kết thúc
            }
            else
            {
                lblTrangthai.Text = "Đang diễn ra";
                lblDemnguoc.Text = "Kết thúc sau: " + (_endTime - currentTime).ToString(@"hh\:mm\:ss");
            }
        }

        private void lblBienso_Click(object sender, EventArgs e)
        {

        }

        private void UCProduct_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void UCProduct_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void UCProduct_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
