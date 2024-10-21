namespace client
{
    partial class Payment
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            rbMomo = new RadioButton();
            pictureBox2 = new PictureBox();
            rbPaypal = new RadioButton();
            pictureBox3 = new PictureBox();
            rbATM = new RadioButton();
            pictureBox4 = new PictureBox();
            rbVisa = new RadioButton();
            label3 = new Label();
            textBoxTotal = new TextBox();
            label7 = new Label();
            textBoxPrice = new TextBox();
            label6 = new Label();
            textBoxInfomation = new TextBox();
            label5 = new Label();
            textBoxUserName = new TextBox();
            label4 = new Label();
            btnPay = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 44);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(274, 25);
            label1.TabIndex = 0;
            label1.Text = "PHƯƠNG THỨC THANH TOÁN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(2, 56);
            label2.Name = "label2";
            label2.Size = new Size(225, 20);
            label2.TabIndex = 1;
            label2.Text = "Chọn phương thức thanh toán ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.z5940619016006_1e2058ba24cc729e5cba97c917051b13;
            pictureBox1.Location = new Point(13, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // rbMomo
            // 
            rbMomo.AutoSize = true;
            rbMomo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbMomo.Location = new Point(78, 93);
            rbMomo.Name = "rbMomo";
            rbMomo.Size = new Size(106, 35);
            rbMomo.TabIndex = 3;
            rbMomo.TabStop = true;
            rbMomo.Text = "Momo";
            rbMomo.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.paypal;
            pictureBox2.Location = new Point(13, 157);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // rbPaypal
            // 
            rbPaypal.AutoSize = true;
            rbPaypal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbPaypal.Location = new Point(78, 157);
            rbPaypal.Name = "rbPaypal";
            rbPaypal.Size = new Size(105, 35);
            rbPaypal.TabIndex = 5;
            rbPaypal.TabStop = true;
            rbPaypal.Text = "Paypal";
            rbPaypal.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.credit_card;
            pictureBox3.Location = new Point(11, 225);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // rbATM
            // 
            rbATM.AutoSize = true;
            rbATM.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbATM.Location = new Point(79, 240);
            rbATM.Name = "rbATM";
            rbATM.Size = new Size(84, 35);
            rbATM.TabIndex = 7;
            rbATM.TabStop = true;
            rbATM.Text = "ATM";
            rbATM.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.card;
            pictureBox4.Location = new Point(11, 312);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // rbVisa
            // 
            rbVisa.AutoSize = true;
            rbVisa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbVisa.Location = new Point(79, 327);
            rbVisa.Name = "rbVisa";
            rbVisa.Size = new Size(86, 35);
            rbVisa.TabIndex = 9;
            rbVisa.TabStop = true;
            rbVisa.Text = "VISA";
            rbVisa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(496, 56);
            label3.Name = "label3";
            label3.Size = new Size(190, 20);
            label3.TabIndex = 10;
            label3.Text = "Thông tin cần thanh toán ";
            // 
            // textBoxTotal
            // 
            textBoxTotal.BackColor = SystemColors.ActiveCaption;
            textBoxTotal.Location = new Point(473, 351);
            textBoxTotal.Multiline = true;
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(307, 35);
            textBoxTotal.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(296, 357);
            label7.Name = "label7";
            label7.Size = new Size(175, 25);
            label7.TabIndex = 25;
            label7.Text = "Số tiền thanh toán:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.BackColor = SystemColors.ActiveCaption;
            textBoxPrice.Location = new Point(473, 304);
            textBoxPrice.Multiline = true;
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(303, 33);
            textBoxPrice.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(297, 312);
            label6.Name = "label6";
            label6.Size = new Size(165, 25);
            label6.TabIndex = 23;
            label6.Text = "Giá trúng đấu giá:";
            // 
            // textBoxInfomation
            // 
            textBoxInfomation.BackColor = SystemColors.ActiveCaption;
            textBoxInfomation.Location = new Point(474, 139);
            textBoxInfomation.Multiline = true;
            textBoxInfomation.Name = "textBoxInfomation";
            textBoxInfomation.Size = new Size(302, 148);
            textBoxInfomation.TabIndex = 22;
            textBoxInfomation.TextChanged += textBoxInfomation_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(296, 181);
            label5.Name = "label5";
            label5.Size = new Size(166, 25);
            label5.TabIndex = 21;
            label5.Text = "Thông tin biển số:";
            // 
            // textBoxUserName
            // 
            textBoxUserName.BackColor = SystemColors.ActiveCaption;
            textBoxUserName.Location = new Point(475, 95);
            textBoxUserName.Multiline = true;
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(300, 24);
            textBoxUserName.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(296, 93);
            label4.Name = "label4";
            label4.Size = new Size(132, 25);
            label4.TabIndex = 19;
            label4.Text = "Tên tài khoản:";
            // 
            // btnPay
            // 
            btnPay.AutoSize = true;
            btnPay.BackColor = SystemColors.ActiveCaption;
            btnPay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.Black;
            btnPay.Location = new Point(474, 413);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(103, 33);
            btnPay.TabIndex = 27;
            btnPay.Text = "Thanh toán ";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = SystemColors.ActiveCaption;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(646, 413);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(103, 33);
            btnCancel.TabIndex = 28;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 451);
            Controls.Add(btnCancel);
            Controls.Add(btnPay);
            Controls.Add(textBoxTotal);
            Controls.Add(label7);
            Controls.Add(textBoxPrice);
            Controls.Add(label6);
            Controls.Add(textBoxInfomation);
            Controls.Add(label5);
            Controls.Add(textBoxUserName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(rbVisa);
            Controls.Add(pictureBox4);
            Controls.Add(rbATM);
            Controls.Add(pictureBox3);
            Controls.Add(rbPaypal);
            Controls.Add(pictureBox2);
            Controls.Add(rbMomo);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "Payment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment";
            Load += Payment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private RadioButton rbMomo;
        private PictureBox pictureBox2;
        private RadioButton rbPaypal;
        private PictureBox pictureBox3;
        private RadioButton rbATM;
        private PictureBox pictureBox4;
        private RadioButton rbVisa;
        private Label label3;
        private TextBox textBoxTotal;
        private Label label7;
        private TextBox textBoxPrice;
        private Label label6;
        private TextBox textBoxInfomation;
        private Label label5;
        private TextBox textBoxUserName;
        private Label label4;
        private Button btnPay;
        private Button btnCancel;
    }
}