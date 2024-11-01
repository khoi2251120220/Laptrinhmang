namespace Client
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            panel1 = new Panel();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            lịchSửToolStripMenuItem = new ToolStripMenuItem();
            tàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 157);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.MenuHighlight;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.Location = new Point(421, 90);
            label4.Name = "label4";
            label4.Size = new Size(128, 17);
            label4.TabIndex = 2;
            label4.Text = "thực hiện bởi nhóm 2";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.gioithieu;
            pictureBox1.Location = new Point(29, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 127);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(234, 48);
            label1.Name = "label1";
            label1.Size = new Size(503, 32);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng bạn đến với đấu giá biển số xe";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 183);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 265);
            panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveBorder;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(29, 57);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(721, 163);
            textBox1.TabIndex = 2;
            textBox1.Text = resources.GetString("textBox1.Text");
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 16);
            label2.Name = "label2";
            label2.Size = new Size(338, 23);
            label2.TabIndex = 0;
            label2.Text = "Giới Thiệu Ứng Dụng Đấu Giá Biển Số Xe";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, lịchSửToolStripMenuItem, tàiKhoảnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(71, 20);
            trangChủToolStripMenuItem.Text = "Trang chủ";
            trangChủToolStripMenuItem.Click += trangChủToolStripMenuItem_Click;
            // 
            // lịchSửToolStripMenuItem
            // 
            lịchSửToolStripMenuItem.Name = "lịchSửToolStripMenuItem";
            lịchSửToolStripMenuItem.Size = new Size(56, 20);
            lịchSửToolStripMenuItem.Text = "Lịch sử";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinTàiKhoảnToolStripMenuItem, logOutToolStripMenuItem });
            tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            tàiKhoảnToolStripMenuItem.Size = new Size(69, 20);
            tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            thôngTinTàiKhoảnToolStripMenuItem.Size = new Size(180, 22);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(180, 22);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "About";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label4;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem lịchSửToolStripMenuItem;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}