using Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace chứa các lớp liên quan đến giao diện người dùng của ứng dụng.
namespace Client
{
    public partial class FormAddNewEmployee : Form
    {
        // Biến để lưu trữ một đối tượng AuctionClient, giúp kết nối với dịch vụ từ phía server.
        private AuctionClient _client;

        // Constructor của form, nhận đối tượng AuctionClient làm tham số.
        public FormAddNewEmployee(AuctionClient client)
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện.
            _client = client; // Gán giá trị AuctionClient cho biến thành viên.
        }

        // Sự kiện xảy ra khi form được tải.
        private void FormAddNewEmployee_Load(object sender, EventArgs e)
        {
            // Gán danh sách giới tính vào combobox cboSex.
            cboSex.DataSource = Const.listSex;
        }

        // Sự kiện khi nhấn vào button1 (Thêm nhân viên mới).
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin bắt buộc đã được nhập chưa.
            if (string.IsNullOrWhiteSpace(cboId.Text) ||
                string.IsNullOrWhiteSpace(cboName.Text) ||
                string.IsNullOrWhiteSpace(cboBirthday.Text) ||
                string.IsNullOrWhiteSpace(cboSex.Text) ||
                string.IsNullOrWhiteSpace(cboPhone.Text) ||
                string.IsNullOrWhiteSpace(cboAddress.Text))
            {
                // Hiển thị thông báo nếu có trường bị để trống.
                MessageBox.Show("Xin hãy nhập đầy đủ các thông tin.");
                return; // Dừng thực hiện tiếp.
            }

            // Kiểm tra và chuyển đổi giá trị ID.
            int id;
            if (!int.TryParse(cboId.Text, out id))
            {
                // Hiển thị thông báo nếu ID không phải số nguyên hợp lệ.
                MessageBox.Show("Dữ liệu không hợp lệ cho ID. Xin hãy nhập một số nguyên hợp lệ.");
                return;
            }

            // Gán giá trị tên.
            string name = cboName.Text;

            // Kiểm tra và chuyển đổi giá trị ngày sinh.
            DateTime birthday;
            if (!DateTime.TryParse(cboBirthday.Text, out birthday))
            {
                // Hiển thị thông báo nếu ngày sinh không hợp lệ.
                MessageBox.Show("Dữ liệu không hợp lệ cho ngày sinh. Xin hãy nhập một ngày sinh hợp lệ.");
                return;
            }

            // Gán giá trị giới tính.
            string sex = cboSex.Text;

            // Kiểm tra và chuyển đổi giá trị số điện thoại.
            int phone;
            if (!int.TryParse(cboPhone.Text, out phone))
            {
                // Hiển thị thông báo nếu số điện thoại không phải số nguyên hợp lệ.
                MessageBox.Show("Dữ liệu không hợp lệ cho số điện thoại. Xin hãy nhập một số nguyên hợp lệ.");
                return;
            }

            // Gán giá trị địa chỉ.
            string address = cboAddress.Text;

            // Tạo một đối tượng Employee mới và gán giá trị.
            Const.NewEmploy = new Employee(id, name, sex, birthday, address, phone);

            // Đóng form hiện tại.
            this.Close();
        }

        // Sự kiện khi nội dung của txbName thay đổi (Hiện tại không thực hiện gì).
        private void txbName_TextChanged(object sender, EventArgs e)
        {

        }

        // Sự kiện khi nhấn vào button2 (Chuyển sang form QLND).
        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng form QLND và hiển thị nó.
            QLND qLND = new QLND(_client);
            this.Hide(); // Ẩn form hiện tại.
        }

        // Sự kiện khi giá trị của cboSex thay đổi (Hiện tại không thực hiện gì).
        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
