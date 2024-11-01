namespace Client
{
    partial class FormShowInfoEmployee
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
            groupBox1 = new GroupBox();
            button2 = new Button();
            txbSex = new ComboBox();
            txbPhone = new TextBox();
            txbAddress = new TextBox();
            txbBirthday = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txbId = new TextBox();
            label4 = new Label();
            txbName = new TextBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(txbSex);
            groupBox1.Controls.Add(txbPhone);
            groupBox1.Controls.Add(txbAddress);
            groupBox1.Controls.Add(txbBirthday);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txbId);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txbName);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(557, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cá nhân";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(409, 198);
            button2.Name = "button2";
            button2.Size = new Size(80, 29);
            button2.TabIndex = 28;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txbSex
            // 
            txbSex.FormattingEnabled = true;
            txbSex.Location = new Point(409, 47);
            txbSex.Name = "txbSex";
            txbSex.Size = new Size(121, 23);
            txbSex.TabIndex = 27;
            // 
            // txbPhone
            // 
            txbPhone.Location = new Point(409, 93);
            txbPhone.Name = "txbPhone";
            txbPhone.Size = new Size(121, 23);
            txbPhone.TabIndex = 26;
            // 
            // txbAddress
            // 
            txbAddress.Location = new Point(409, 134);
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(121, 23);
            txbAddress.TabIndex = 25;
            // 
            // txbBirthday
            // 
            txbBirthday.Location = new Point(121, 139);
            txbBirthday.Name = "txbBirthday";
            txbBirthday.Size = new Size(121, 23);
            txbBirthday.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(304, 97);
            label8.Name = "label8";
            label8.Size = new Size(90, 17);
            label8.TabIndex = 23;
            label8.Text = "Số điện thoại";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(304, 51);
            label7.Name = "label7";
            label7.Size = new Size(62, 17);
            label7.TabIndex = 22;
            label7.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(304, 145);
            label6.Name = "label6";
            label6.Size = new Size(51, 17);
            label6.TabIndex = 21;
            label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(41, 140);
            label5.Name = "label5";
            label5.Size = new Size(70, 17);
            label5.TabIndex = 20;
            label5.Text = "Ngày sinh";
            // 
            // txbId
            // 
            txbId.Location = new Point(121, 45);
            txbId.Name = "txbId";
            txbId.Size = new Size(121, 23);
            txbId.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(41, 93);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 18;
            label4.Text = "Họ và tên";
            // 
            // txbName
            // 
            txbName.Cursor = Cursors.IBeam;
            txbName.Location = new Point(121, 91);
            txbName.Name = "txbName";
            txbName.Size = new Size(121, 23);
            txbName.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 45);
            label3.Name = "label3";
            label3.Size = new Size(27, 21);
            label3.TabIndex = 16;
            label3.Text = "ID";
            // 
            // FormShowInfoEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 272);
            Controls.Add(groupBox1);
            Name = "FormShowInfoEmployee";
            Text = "FormShowInfoEmployee";
            Load += FormShowInfoEmployee_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox txbSex;
        private TextBox txbPhone;
        private TextBox txbAddress;
        private TextBox txbBirthday;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txbId;
        private Label label4;
        private TextBox txbName;
        private Label label3;
        private Button button2;
    }
}