namespace client
{
    partial class History
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
            dataGridViewPaymentHistory = new DataGridView();
            code = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            transactionInfo = new DataGridViewTextBoxColumn();
            amuont = new DataGridViewTextBoxColumn();
            paymentHistory = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaymentHistory).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1004, 51);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(318, 9);
            label1.Name = "label1";
            label1.Size = new Size(326, 38);
            label1.TabIndex = 0;
            label1.Text = "LỊCH SỬ THANH TOÁN ";
            // 
            // dataGridViewPaymentHistory
            // 
            dataGridViewPaymentHistory.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewPaymentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPaymentHistory.Columns.AddRange(new DataGridViewColumn[] { code, username, transactionInfo, amuont, paymentHistory, status });
            dataGridViewPaymentHistory.Location = new Point(0, 76);
            dataGridViewPaymentHistory.Name = "dataGridViewPaymentHistory";
            dataGridViewPaymentHistory.ReadOnly = true;
            dataGridViewPaymentHistory.RowHeadersWidth = 51;
            dataGridViewPaymentHistory.Size = new Size(1004, 370);
            dataGridViewPaymentHistory.TabIndex = 1;
            // 
            // code
            // 
            code.HeaderText = "Mã số ";
            code.MinimumWidth = 6;
            code.Name = "code";
            code.ReadOnly = true;
            code.Width = 125;
            // 
            // username
            // 
            username.HeaderText = "Người dùng";
            username.MinimumWidth = 6;
            username.Name = "username";
            username.ReadOnly = true;
            username.Width = 150;
            // 
            // transactionInfo
            // 
            transactionInfo.HeaderText = "Thông tin biển số";
            transactionInfo.MinimumWidth = 6;
            transactionInfo.Name = "transactionInfo";
            transactionInfo.ReadOnly = true;
            transactionInfo.Width = 250;
            // 
            // amuont
            // 
            amuont.HeaderText = "Số tiền";
            amuont.MinimumWidth = 6;
            amuont.Name = "amuont";
            amuont.ReadOnly = true;
            amuont.Width = 150;
            // 
            // paymentHistory
            // 
            paymentHistory.HeaderText = "Phương thức thanh toán";
            paymentHistory.MinimumWidth = 6;
            paymentHistory.Name = "paymentHistory";
            paymentHistory.ReadOnly = true;
            paymentHistory.Width = 150;
            // 
            // status
            // 
            status.HeaderText = "Trạng thái ";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 150;
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1004, 450);
            Controls.Add(dataGridViewPaymentHistory);
            Controls.Add(panel1);
            Name = "History";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử";
            Load += History_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaymentHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dataGridViewPaymentHistory;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn transactionInfo;
        private DataGridViewTextBoxColumn amuont;
        private DataGridViewTextBoxColumn paymentHistory;
        private DataGridViewTextBoxColumn status;
    }
}