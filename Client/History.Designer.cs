namespace Client
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
            id = new DataGridViewTextBoxColumn();
            history_username = new DataGridViewTextBoxColumn();
            history_license_plate = new DataGridViewTextBoxColumn();
            history_amount = new DataGridViewTextBoxColumn();
            payment_method = new DataGridViewTextBoxColumn();
            payment_time = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaymentHistory).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1053, 46);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(367, 10);
            label1.Name = "label1";
            label1.Size = new Size(266, 31);
            label1.TabIndex = 0;
            label1.Text = "LỊCH SỬ THANH TOÁN ";
            // 
            // dataGridViewPaymentHistory
            // 
            dataGridViewPaymentHistory.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewPaymentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPaymentHistory.Columns.AddRange(new DataGridViewColumn[] { id, history_username, history_license_plate, history_amount, payment_method, payment_time, status });
            dataGridViewPaymentHistory.Location = new Point(0, 63);
            dataGridViewPaymentHistory.Name = "dataGridViewPaymentHistory";
            dataGridViewPaymentHistory.RowHeadersWidth = 51;
            dataGridViewPaymentHistory.Size = new Size(928, 390);
            dataGridViewPaymentHistory.TabIndex = 1;
            // 
            // id
            // 
            id.HeaderText = "Mã thanh toán ";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 125;
            // 
            // history_username
            // 
            history_username.HeaderText = "Tên tài khoản ";
            history_username.MinimumWidth = 6;
            history_username.Name = "history_username";
            history_username.ReadOnly = true;
            history_username.Width = 125;
            // 
            // history_license_plate
            // 
            history_license_plate.HeaderText = "Thông tin biển số ";
            history_license_plate.MinimumWidth = 6;
            history_license_plate.Name = "history_license_plate";
            history_license_plate.ReadOnly = true;
            history_license_plate.Width = 125;
            // 
            // history_amount
            // 
            history_amount.HeaderText = "Số tiền";
            history_amount.MinimumWidth = 6;
            history_amount.Name = "history_amount";
            history_amount.ReadOnly = true;
            history_amount.Width = 125;
            // 
            // payment_method
            // 
            payment_method.HeaderText = "Phương thức thanh toán ";
            payment_method.MinimumWidth = 6;
            payment_method.Name = "payment_method";
            payment_method.ReadOnly = true;
            payment_method.Width = 125;
            // 
            // payment_time
            // 
            payment_time.HeaderText = "Thời gian";
            payment_time.MinimumWidth = 6;
            payment_time.Name = "payment_time";
            payment_time.ReadOnly = true;
            payment_time.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Trạng thái ";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 125;
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(929, 450);
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
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn history_username;
        private DataGridViewTextBoxColumn history_license_plate;
        private DataGridViewTextBoxColumn history_amount;
        private DataGridViewTextBoxColumn payment_method;
        private DataGridViewTextBoxColumn payment_time;
        private DataGridViewTextBoxColumn status;
    }
}