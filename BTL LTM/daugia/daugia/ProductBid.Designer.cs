namespace client
{
    partial class ProductBid
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDeDauGia;
        private Label lblBienSoXeTieuDe;
        private Label lblBienSoXeGiaTri;
        private Label lblGiaHienTaiTieuDe;
        private Label lblGiaHienTaiGiaTri;
        private Label lblThoiGianConLaiTieuDe;
        private Label lblThoiGianConLaiGiaTri;
        private TextBox txtGiaMoi;
        private Button btnDatGia;
        private Label lblLichSuDauGia;
        private ListBox lstLichSuDauGia;
        private Panel mainPanel;
        private MenuStrip menuStrip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            lblTieuDeDauGia = new Label();
            lblBienSoXeTieuDe = new Label();
            lblBienSoXeGiaTri = new Label();
            lblGiaHienTaiTieuDe = new Label();
            lblGiaHienTaiGiaTri = new Label();
            lblThoiGianConLaiTieuDe = new Label();
            lblThoiGianConLaiGiaTri = new Label();
            txtGiaMoi = new TextBox();
            btnDatGia = new Button();
            lblLichSuDauGia = new Label();
            lstLichSuDauGia = new ListBox();
            menuStrip = new MenuStrip();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.LightSeaGreen;
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(lblTieuDeDauGia);
            mainPanel.Controls.Add(lblBienSoXeTieuDe);
            mainPanel.Controls.Add(lblBienSoXeGiaTri);
            mainPanel.Controls.Add(lblGiaHienTaiTieuDe);
            mainPanel.Controls.Add(lblGiaHienTaiGiaTri);
            mainPanel.Controls.Add(lblThoiGianConLaiTieuDe);
            mainPanel.Controls.Add(lblThoiGianConLaiGiaTri);
            mainPanel.Controls.Add(txtGiaMoi);
            mainPanel.Controls.Add(btnDatGia);
            mainPanel.Controls.Add(lblLichSuDauGia);
            mainPanel.Controls.Add(lstLichSuDauGia);
            mainPanel.Location = new Point(100, 80);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(600, 400);
            mainPanel.TabIndex = 0;
            // 
            // lblTieuDeDauGia
            // 
            lblTieuDeDauGia.AutoSize = true;
            lblTieuDeDauGia.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDeDauGia.ForeColor = Color.White;
            lblTieuDeDauGia.Location = new Point(170, 20);
            lblTieuDeDauGia.Name = "lblTieuDeDauGia";
            lblTieuDeDauGia.Size = new Size(227, 30);
            lblTieuDeDauGia.TabIndex = 0;
            lblTieuDeDauGia.Text = "ĐẤU GIÁ BIỂN SỐ XE";
            // 
            // lblBienSoXeTieuDe
            // 
            lblBienSoXeTieuDe.AutoSize = true;
            lblBienSoXeTieuDe.Font = new Font("Segoe UI", 12F);
            lblBienSoXeTieuDe.ForeColor = Color.White;
            lblBienSoXeTieuDe.Location = new Point(170, 80);
            lblBienSoXeTieuDe.Name = "lblBienSoXeTieuDe";
            lblBienSoXeTieuDe.Size = new Size(86, 21);
            lblBienSoXeTieuDe.TabIndex = 1;
            lblBienSoXeTieuDe.Text = "Biển Số Xe:";
            // 
            // lblBienSoXeGiaTri
            // 
            lblBienSoXeGiaTri.AutoSize = true;
            lblBienSoXeGiaTri.BackColor = Color.White;
            lblBienSoXeGiaTri.BorderStyle = BorderStyle.FixedSingle;
            lblBienSoXeGiaTri.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienSoXeGiaTri.ForeColor = Color.Black;
            lblBienSoXeGiaTri.Location = new Point(262, 65);
            lblBienSoXeGiaTri.Name = "lblBienSoXeGiaTri";
            lblBienSoXeGiaTri.Size = new Size(153, 47);
            lblBienSoXeGiaTri.TabIndex = 2;
            lblBienSoXeGiaTri.Text = "ABC-123";
            // 
            // lblGiaHienTaiTieuDe
            // 
            lblGiaHienTaiTieuDe.AutoSize = true;
            lblGiaHienTaiTieuDe.Font = new Font("Segoe UI", 12F);
            lblGiaHienTaiTieuDe.ForeColor = Color.White;
            lblGiaHienTaiTieuDe.Location = new Point(170, 131);
            lblGiaHienTaiTieuDe.Name = "lblGiaHienTaiTieuDe";
            lblGiaHienTaiTieuDe.Size = new Size(96, 21);
            lblGiaHienTaiTieuDe.TabIndex = 3;
            lblGiaHienTaiTieuDe.Text = "Giá Hiện Tại:";
            // 
            // lblGiaHienTaiGiaTri
            // 
            lblGiaHienTaiGiaTri.AutoSize = true;
            lblGiaHienTaiGiaTri.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGiaHienTaiGiaTri.ForeColor = Color.White;
            lblGiaHienTaiGiaTri.Location = new Point(263, 131);
            lblGiaHienTaiGiaTri.Name = "lblGiaHienTaiGiaTri";
            lblGiaHienTaiGiaTri.Size = new Size(121, 21);
            lblGiaHienTaiGiaTri.TabIndex = 4;
            lblGiaHienTaiGiaTri.Text = "1.000.000 VND";
            // 
            // lblThoiGianConLaiTieuDe
            // 
            lblThoiGianConLaiTieuDe.AutoSize = true;
            lblThoiGianConLaiTieuDe.Font = new Font("Segoe UI", 12F);
            lblThoiGianConLaiTieuDe.ForeColor = Color.White;
            lblThoiGianConLaiTieuDe.Location = new Point(170, 156);
            lblThoiGianConLaiTieuDe.Name = "lblThoiGianConLaiTieuDe";
            lblThoiGianConLaiTieuDe.Size = new Size(136, 21);
            lblThoiGianConLaiTieuDe.TabIndex = 5;
            lblThoiGianConLaiTieuDe.Text = "Thời Gian Còn Lại:";
            // 
            // lblThoiGianConLaiGiaTri
            // 
            lblThoiGianConLaiGiaTri.AutoSize = true;
            lblThoiGianConLaiGiaTri.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblThoiGianConLaiGiaTri.ForeColor = Color.White;
            lblThoiGianConLaiGiaTri.Location = new Point(312, 156);
            lblThoiGianConLaiGiaTri.Name = "lblThoiGianConLaiGiaTri";
            lblThoiGianConLaiGiaTri.Size = new Size(72, 21);
            lblThoiGianConLaiGiaTri.TabIndex = 6;
            lblThoiGianConLaiGiaTri.Text = "00:05:30";
            // 
            // txtGiaMoi
            // 
            txtGiaMoi.BackColor = Color.White;
            txtGiaMoi.BorderStyle = BorderStyle.FixedSingle;
            txtGiaMoi.Font = new Font("Segoe UI", 12F);
            txtGiaMoi.Location = new Point(170, 186);
            txtGiaMoi.Name = "txtGiaMoi";
            txtGiaMoi.PlaceholderText = "Nhập giá tại đây...";
            txtGiaMoi.Size = new Size(200, 29);
            txtGiaMoi.TabIndex = 7;
            // 
            // btnDatGia
            // 
            btnDatGia.BackColor = Color.White;
            btnDatGia.Cursor = Cursors.Hand;
            btnDatGia.FlatAppearance.BorderSize = 0;
            btnDatGia.FlatStyle = FlatStyle.Flat;
            btnDatGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDatGia.ForeColor = Color.LightSeaGreen;
            btnDatGia.Location = new Point(376, 186);
            btnDatGia.Name = "btnDatGia";
            btnDatGia.Size = new Size(100, 30);
            btnDatGia.TabIndex = 8;
            btnDatGia.Text = "Đặt Giá";
            btnDatGia.UseVisualStyleBackColor = false;
            // 
            // lblLichSuDauGia
            // 
            lblLichSuDauGia.AutoSize = true;
            lblLichSuDauGia.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLichSuDauGia.ForeColor = Color.White;
            lblLichSuDauGia.Location = new Point(170, 230);
            lblLichSuDauGia.Name = "lblLichSuDauGia";
            lblLichSuDauGia.Size = new Size(194, 30);
            lblLichSuDauGia.TabIndex = 9;
            lblLichSuDauGia.Text = "LỊCH SỬ ĐẤU GIÁ";
            // 
            // lstLichSuDauGia
            // 
            lstLichSuDauGia.BackColor = Color.White;
            lstLichSuDauGia.BorderStyle = BorderStyle.FixedSingle;
            lstLichSuDauGia.Font = new Font("Segoe UI", 12F);
            lstLichSuDauGia.ItemHeight = 21;
            lstLichSuDauGia.Location = new Point(104, 277);
            lstLichSuDauGia.Name = "lstLichSuDauGia";
            lstLichSuDauGia.Size = new Size(400, 86);
            lstLichSuDauGia.TabIndex = 10;
            // 
            // menuStrip
            // 
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 11;
            menuStrip.Text = "menuStrip";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 500);
            Controls.Add(menuStrip);
            Controls.Add(mainPanel);
            Name = "Form3";
            Text = "Đấu Giá Biển Số Xe";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
