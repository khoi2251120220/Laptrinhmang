namespace Client
{
    partial class FormAddNewEmployee
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
            panel2 = new Panel();
            cboSex = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            cboPhone = new TextBox();
            cboAddress = new TextBox();
            cboBirthday = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            cboId = new TextBox();
            label4 = new Label();
            cboName = new TextBox();
            label3 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(cboSex);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(cboPhone);
            panel2.Controls.Add(cboAddress);
            panel2.Controls.Add(cboBirthday);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cboId);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(cboName);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(0, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(569, 215);
            panel2.TabIndex = 3;
            // 
            // cboSex
            // 
            cboSex.FormattingEnabled = true;
            cboSex.Location = new Point(386, 105);
            cboSex.Name = "cboSex";
            cboSex.Size = new Size(121, 23);
            cboSex.TabIndex = 15;
            cboSex.SelectedIndexChanged += cboSex_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(457, 158);
            button2.Name = "button2";
            button2.Size = new Size(80, 29);
            button2.TabIndex = 14;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(347, 158);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 13;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cboPhone
            // 
            cboPhone.Location = new Point(386, 63);
            cboPhone.Name = "cboPhone";
            cboPhone.Size = new Size(121, 23);
            cboPhone.TabIndex = 12;
            // 
            // cboAddress
            // 
            cboAddress.Location = new Point(386, 24);
            cboAddress.Name = "cboAddress";
            cboAddress.Size = new Size(121, 23);
            cboAddress.TabIndex = 10;
            // 
            // cboBirthday
            // 
            cboBirthday.Location = new Point(101, 105);
            cboBirthday.Name = "cboBirthday";
            cboBirthday.Size = new Size(121, 23);
            cboBirthday.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(285, 63);
            label8.Name = "label8";
            label8.Size = new Size(90, 17);
            label8.TabIndex = 8;
            label8.Text = "Số điện thoại";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(285, 111);
            label7.Name = "label7";
            label7.Size = new Size(62, 17);
            label7.TabIndex = 7;
            label7.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(285, 24);
            label6.Name = "label6";
            label6.Size = new Size(51, 17);
            label6.TabIndex = 6;
            label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 105);
            label5.Name = "label5";
            label5.Size = new Size(70, 17);
            label5.TabIndex = 5;
            label5.Text = "Ngày sinh";
            // 
            // cboId
            // 
            cboId.Location = new Point(101, 18);
            cboId.Name = "cboId";
            cboId.Size = new Size(121, 23);
            cboId.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 63);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 3;
            label4.Text = "Họ và tên";
            // 
            // cboName
            // 
            cboName.Cursor = Cursors.IBeam;
            cboName.Location = new Point(101, 63);
            cboName.Name = "cboName";
            cboName.Size = new Size(121, 23);
            cboName.TabIndex = 1;
            cboName.TextChanged += txbName_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 16);
            label3.Name = "label3";
            label3.Size = new Size(27, 21);
            label3.TabIndex = 0;
            label3.Text = "ID";
            // 
            // FormAddNewEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 227);
            Controls.Add(panel2);
            Name = "FormAddNewEmployee";
            Text = "FormAddNewEmployee";
            Load += FormAddNewEmployee_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button2;
        private Button button1;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox cboSex;
        private TextBox cboPhone;
        private TextBox cboAddress;
        private TextBox cboBirthday;
        private TextBox cboId;
        private TextBox cboName;
    }
}