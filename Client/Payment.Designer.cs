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
            radioButtonMomo = new RadioButton();
            pictureBox2 = new PictureBox();
            radioButtonPaypal = new RadioButton();
            pictureBox3 = new PictureBox();
            radioButtonATM = new RadioButton();
            pictureBox4 = new PictureBox();
            radioButtonVisa = new RadioButton();
            label3 = new Label();
            textBoxTotalAmount = new TextBox();
            label7 = new Label();
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
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(697, 33);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 7);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 0;
            label1.Text = "PHƯƠNG THỨC THANH TOÁN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(2, 42);
            label2.Name = "label2";
            label2.Size = new Size(177, 15);
            label2.TabIndex = 1;
            label2.Text = "Chọn phương thức thanh toán ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Client.Properties.Resources.z5940619016006_1e2058ba24cc729e5cba97c917051b13;
            pictureBox1.Location = new Point(11, 66);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // radioButtonMomo
            // 
            radioButtonMomo.AutoSize = true;
            radioButtonMomo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonMomo.Location = new Point(68, 70);
            radioButtonMomo.Margin = new Padding(3, 2, 3, 2);
            radioButtonMomo.Name = "radioButtonMomo";
            radioButtonMomo.Size = new Size(89, 29);
            radioButtonMomo.TabIndex = 3;
            radioButtonMomo.TabStop = true;
            radioButtonMomo.Text = "Momo";
            radioButtonMomo.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Client.Properties.Resources.paypal;
            pictureBox2.Location = new Point(11, 118);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // radioButtonPaypal
            // 
            radioButtonPaypal.AutoSize = true;
            radioButtonPaypal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonPaypal.Location = new Point(68, 118);
            radioButtonPaypal.Margin = new Padding(3, 2, 3, 2);
            radioButtonPaypal.Name = "radioButtonPaypal";
            radioButtonPaypal.Size = new Size(89, 29);
            radioButtonPaypal.TabIndex = 5;
            radioButtonPaypal.TabStop = true;
            radioButtonPaypal.Text = "Paypal";
            radioButtonPaypal.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Client.Properties.Resources.credit_card;
            pictureBox3.Location = new Point(10, 169);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(44, 38);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // radioButtonATM
            // 
            radioButtonATM.AutoSize = true;
            radioButtonATM.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonATM.Location = new Point(69, 180);
            radioButtonATM.Margin = new Padding(3, 2, 3, 2);
            radioButtonATM.Name = "radioButtonATM";
            radioButtonATM.Size = new Size(71, 29);
            radioButtonATM.TabIndex = 7;
            radioButtonATM.TabStop = true;
            radioButtonATM.Text = "ATM";
            radioButtonATM.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Client.Properties.Resources.card;
            pictureBox4.Location = new Point(10, 234);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(44, 38);
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // radioButtonVisa
            // 
            radioButtonVisa.AutoSize = true;
            radioButtonVisa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonVisa.Location = new Point(69, 245);
            radioButtonVisa.Margin = new Padding(3, 2, 3, 2);
            radioButtonVisa.Name = "radioButtonVisa";
            radioButtonVisa.Size = new Size(73, 29);
            radioButtonVisa.TabIndex = 9;
            radioButtonVisa.TabStop = true;
            radioButtonVisa.Text = "VISA";
            radioButtonVisa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(434, 42);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 10;
            label3.Text = "Thông tin cần thanh toán ";
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.BackColor = SystemColors.ActiveCaption;
            textBoxTotalAmount.Location = new Point(414, 263);
            textBoxTotalAmount.Margin = new Padding(3, 2, 3, 2);
            textBoxTotalAmount.Multiline = true;
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.Size = new Size(269, 27);
            textBoxTotalAmount.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(259, 268);
            label7.Name = "label7";
            label7.Size = new Size(142, 20);
            label7.TabIndex = 25;
            label7.Text = "Số tiền thanh toán:";
            // 
            // textBoxInfomation
            // 
            textBoxInfomation.BackColor = SystemColors.ActiveCaption;
            textBoxInfomation.Location = new Point(415, 104);
            textBoxInfomation.Margin = new Padding(3, 2, 3, 2);
            textBoxInfomation.Multiline = true;
            textBoxInfomation.Name = "textBoxInfomation";
            textBoxInfomation.ReadOnly = true;
            textBoxInfomation.Size = new Size(265, 112);
            textBoxInfomation.TabIndex = 22;
            textBoxInfomation.TextChanged += textBoxInfomation_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(259, 136);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 21;
            label5.Text = "Thông tin biển số:";
            // 
            // textBoxUserName
            // 
            textBoxUserName.BackColor = SystemColors.ActiveCaption;
            textBoxUserName.Location = new Point(416, 71);
            textBoxUserName.Margin = new Padding(3, 2, 3, 2);
            textBoxUserName.Multiline = true;
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(263, 30);
            textBoxUserName.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(259, 70);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 19;
            label4.Text = "Tên tài khoản:";
            // 
            // btnPay
            // 
            btnPay.AutoSize = true;
            btnPay.BackColor = SystemColors.ActiveCaption;
            btnPay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.Black;
            btnPay.Location = new Point(415, 310);
            btnPay.Margin = new Padding(3, 2, 3, 2);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(90, 25);
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
            btnCancel.Location = new Point(565, 310);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 25);
            btnCancel.TabIndex = 28;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(700, 345);
            Controls.Add(btnCancel);
            Controls.Add(btnPay);
            Controls.Add(textBoxTotalAmount);
            Controls.Add(label7);
            Controls.Add(textBoxInfomation);
            Controls.Add(label5);
            Controls.Add(textBoxUserName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(radioButtonVisa);
            Controls.Add(pictureBox4);
            Controls.Add(radioButtonATM);
            Controls.Add(pictureBox3);
            Controls.Add(radioButtonPaypal);
            Controls.Add(pictureBox2);
            Controls.Add(radioButtonMomo);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
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
        private RadioButton radioButtonMomo;
        private PictureBox pictureBox2;
        private RadioButton radioButtonPaypal;
        private PictureBox pictureBox3;
        private RadioButton radioButtonATM;
        private PictureBox pictureBox4;
        private RadioButton radioButtonVisa;
        private Label label3;
        private TextBox textBoxTotalAmount;
        private Label label7;
        private TextBox textBoxInfomation;
        private Label label5;
        private TextBox textBoxUserName;
        private Label label4;
        private Button btnPay;
        private Button btnCancel;
    }
}