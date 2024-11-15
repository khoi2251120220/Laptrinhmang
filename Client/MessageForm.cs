using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class MessageForm : Form
    {
        private System.Windows.Forms.Timer _timer;

        public MessageForm(string message, string title, int duration)
        {
            // Cài đặt form
            this.Text = title;
            this.Size = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Label hiển thị thông báo
            var label = new Label
            {
                Text = message,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 12),
                Height = 80
            };
            this.Controls.Add(label);

            // Thêm nút đóng
            var closeButton = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 30
            };
            closeButton.Click += (s, e) => this.Close();
            this.Controls.Add(closeButton);

            // Cài đặt timer
            _timer = new System.Windows.Forms.Timer
            {
                Interval = duration
            };
            _timer.Tick += (s, e) =>
            {
                _timer.Stop();
                this.Close();
            };
            _timer.Start();
        }

        public static void Show(string message, string title = "Thông báo", int duration = 3000)
        {
            var msgBox = new MessageForm(message, title, duration);
            msgBox.ShowDialog();
        }
    }
}
