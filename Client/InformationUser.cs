using System;
using System.Windows.Forms;
using Client.Services;
using daugia;
using MySql.Data.MySqlClient;
using Server.Data;

namespace Client
{
    public partial class InformationUser : Form
    {
        private readonly DatabaseContext _dbContext;
        private int _userId;  // ID người dùng hiện tại

        public InformationUser(int userId)  // Truyền ID người dùng vào
        {
            InitializeComponent();
            _dbContext = new DatabaseContext();
            _userId = userId;
            InitializeFormControls();
        }

        private void InitializeFormControls()
        {
            // Họ tên
            Label nameLabel = new Label { Text = "Họ tên:", Location = new Point(20, 20), AutoSize = true };
            TextBox nameTextBox = new TextBox { Location = new Point(100, 20), Width = 200 };
            this.Controls.Add(nameLabel);
            this.Controls.Add(nameTextBox);

            // Ngày sinh
            Label dobLabel = new Label { Text = "Ngày sinh:", Location = new Point(20, 60), AutoSize = true };
            DateTimePicker dobPicker = new DateTimePicker { Location = new Point(100, 60), Format = DateTimePickerFormat.Short };
            this.Controls.Add(dobLabel);
            this.Controls.Add(dobPicker);

            // Địa chỉ
            Label addressLabel = new Label { Text = "Địa chỉ:", Location = new Point(20, 100), AutoSize = true };
            TextBox addressTextBox = new TextBox { Location = new Point(100, 100), Width = 200 };
            this.Controls.Add(addressLabel);
            this.Controls.Add(addressTextBox);

            // Button Lưu
            Button submitButton = new Button { Text = "Lưu", Location = new Point(100, 140) };
            submitButton.Click += async (sender, e) =>
                await SaveUserInfoAsync(nameTextBox.Text, dobPicker.Value, addressTextBox.Text);
            this.Controls.Add(submitButton);

            // Button Quay lại
            Button backButton = new Button { Text = "Quay lại", Location = new Point(200, 140) };
            backButton.Click += (sender, e) => GoBackToHomePage();
            this.Controls.Add(backButton);
        }

        private async Task SaveUserInfoAsync(string fullName, DateTime dob, string address)
        {
            try
            {
                using var conn = _dbContext.GetConnection();
                await conn.OpenAsync();

                string query = @"
                    INSERT INTO user_info (user_id, full_name, date_of_birth, address) 
                    VALUES (@userId, @fullName, @dob, @address) 
                    ON DUPLICATE KEY UPDATE 
                        full_name = @fullName, 
                        date_of_birth = @dob, 
                        address = @address";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@address", address);

                await cmd.ExecuteNonQueryAsync();
                MessageBox.Show("Lưu thông tin thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}", "Lỗi");
            }
        }

        private void GoBackToHomePage()
        {
            HomePage homePage = new HomePage(new AuctionClient(), _userId);
            homePage.Show();
            this.Close();
        }
    }
}
