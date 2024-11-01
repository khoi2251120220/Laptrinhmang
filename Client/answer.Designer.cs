namespace Client
{
    partial class answer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(answer));
            menuStrip1 = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            lịchSửToolStripMenuItem = new ToolStripMenuItem();
            tàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, lịchSửToolStripMenuItem, tàiKhoảnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 446);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(797, 91);
            panel2.TabIndex = 10;
            panel2.Paint += panel2_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(275, 14);
            label5.Name = "label5";
            label5.Size = new Size(232, 32);
            label5.TabIndex = 8;
            label5.Text = "Đấu Giá Biển Số Xe";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(364, 46);
            label6.Name = "label6";
            label6.Size = new Size(54, 17);
            label6.TabIndex = 9;
            label6.Text = "Nhóm 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 341);
            label4.Name = "label4";
            label4.Size = new Size(404, 17);
            label4.TabIndex = 7;
            label4.Text = "* Tôi có thể đợi bao lâu trước khi biển số của tôi được chuyển đi ?";
            label4.Click += label4_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ControlDark;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(27, 368);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(721, 67);
            textBox3.TabIndex = 6;
            textBox3.Text = resources.GetString("textBox3.Text");
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 248);
            label3.Name = "label3";
            label3.Size = new Size(378, 17);
            label3.TabIndex = 5;
            label3.Text = "* Việc vận chuyển diễn ra như thế nào và chi phí bao nhiêu ?";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDark;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(27, 275);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(721, 48);
            textBox1.TabIndex = 4;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlDark;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(27, 183);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(721, 48);
            textBox2.TabIndex = 3;
            textBox2.Text = resources.GetString("textBox2.Text");
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 156);
            label2.Name = "label2";
            label2.Size = new Size(217, 17);
            label2.TabIndex = 1;
            label2.Text = "* Đấu giá hoạt động như thế nào ?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 110);
            label1.Name = "label1";
            label1.Size = new Size(233, 25);
            label1.TabIndex = 0;
            label1.Text = "Các câu hỏi thường gặp :";
            // 
            // answer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 474);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "answer";
            Text = "answer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem lịchSửToolStripMenuItem;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox1;
        private Label label5;
        private Panel panel2;
        private Label label6;
    }
}