using Client.Services;
using daugia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    // Class QLND quản lý giao diện của form Quản Lý Nhân Dựng.
    public partial class QLND : Form
    {
        // Biến index lưu trữ vị trí dòng được chọn trong DataGridView.
        int index = -1;

        // Biến _client dùng để kết nối với server.
        private AuctionClient _client;

        // Constructor của form QLND, nhận đối tượng AuctionClient làm tham số.
        public QLND(AuctionClient client)
        {
            InitializeComponent();  // Khởi tạo giao diện.
            _client = client;  // Gán đối tượng client vào biến _client.
        }

        // Hàm LoadListEmployee để tải danh sách nhân viên vào DataGridView.
        void LoadListEmployee()
        {
            dtgvEmployee.Rows.Clear(); // Xóa các dòng cũ trong DataGridView.

            // Duyệt qua danh sách nhân viên và thêm chúng vào DataGridView.
            foreach (var item in ListEmployee.Instance.ListEmployees)
            {
                dtgvEmployee.Rows.Add(item.Id, item.Name, item.Address, item.Birthday.ToShortDateString(), item.Sex, item.Phone);
            }
        }

        // Sự kiện khi nhấn vào menu "logOutToolStripMenuItem", hiển thị hộp thoại xác nhận đăng xuất.
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo yêu cầu người dùng xác nhận đăng xuất.
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, mở form Login và đóng form hiện tại.
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
                _client.Dispose(); // Giải phóng tài nguyên của _client.
            }
        }

        // Sự kiện khi DataGridView (dtgvEmployee) được click vào một ô, xác định dòng được chọn.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Sự kiện khi form QLND được tải, gọi hàm LoadListEmployee để tải danh sách nhân viên.
        private void QLND_Load(object sender, EventArgs e)
        {
            LoadListEmployee();
        }

        // Sự kiện khi nhấn nút "button1" (thêm nhân viên mới), mở form để thêm nhân viên mới.
        private void button1_Click(object sender, EventArgs e)
        {
            Const.NewEmploy = null; // Đặt lại thông tin nhân viên mới.

            FormAddNewEmployee f = new FormAddNewEmployee(_client);  // Tạo form để thêm nhân viên mới.
            f.FormClosed += F_FormClosed;  // Gán sự kiện khi form đóng lại.
            f.ShowDialog();  // Hiển thị form thêm nhân viên mới dưới dạng hộp thoại.
        }

        // Sự kiện khi form thêm nhân viên mới đóng lại, thêm nhân viên mới vào danh sách và tải lại.
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListEmployee.Instance.ListEmployees.Add(Const.NewEmploy);  // Thêm nhân viên mới vào danh sách.
            LoadListEmployee();  // Tải lại danh sách nhân viên.
        }

        // Sự kiện khi nhấn vào một dòng trong DataGridView, cập nhật thông tin nhân viên được chọn.
        private void dtgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;  // Lưu lại chỉ số dòng được chọn.

            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
                return;  // Nếu chỉ số dòng không hợp lệ, thoát khỏi hàm.

            // Cập nhật thông tin nhân viên đã chọn vào Const.NewEmploy.
            Const.NewEmploy = new Employee();
            Const.NewEmploy.Id = ListEmployee.Instance.ListEmployees[index].Id;
            Const.NewEmploy.Birthday = ListEmployee.Instance.ListEmployees[index].Birthday;
            Const.NewEmploy.Name = ListEmployee.Instance.ListEmployees[index].Name;
            Const.NewEmploy.Sex = ListEmployee.Instance.ListEmployees[index].Sex;
            Const.NewEmploy.Address = ListEmployee.Instance.ListEmployees[index].Address;
            Const.NewEmploy.Phone = ListEmployee.Instance.ListEmployees[index].Phone;
        }

        // Sự kiện khi nhấn nút "button2" (xóa nhân viên), xóa nhân viên đã chọn.
        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn nhân viên nào.
            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
            {
                MessageBox.Show("hãy chọn 1 đối tượng");
                return;
            }

            // Xóa nhân viên đã chọn từ danh sách.
            ListEmployee.Instance.ListEmployees.RemoveAt(index);
            LoadListEmployee();  // Tải lại danh sách nhân viên sau khi xóa.
        }

        // Sự kiện khi nhấn nút "buton_xem" (xem thông tin chi tiết), mở form để xem thông tin nhân viên.
        private void buton_xem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn nhân viên nào.
            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
            {
                MessageBox.Show("hãy chọn 1 đối tượng");
                return;
            }

            // Mở form xem thông tin nhân viên.
            FormShowInfoEmployee formShowInfoEmployee = new FormShowInfoEmployee(_client);
            formShowInfoEmployee.Show();  // Hiển thị form xem thông tin nhân viên.
            this.Close();  // Đóng form hiện tại.
        }

        // Sự kiện vẽ panel (không sử dụng trong mã hiện tại).
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Sự kiện khi nhấn vào menu "trangChủToolStripMenuItem", chuyển sang trang chủ.
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepage_admin homepage_Admin = new Homepage_admin(_client);  // Tạo form trang chủ.
            homepage_Admin.Show();  // Hiển thị form trang chủ.
            this.Close();  // Đóng form hiện tại.
        }

        // Sự kiện khi nhấn vào nút tìm kiếm, lọc danh sách nhân viên theo các điều kiện.
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu.
            string idText = txtId.Text.Trim();
            string nameText = txtName.Text.Trim();
            string genderText = txtSex.Text.Trim();
            string phoneText = txtPhone.Text.Trim();

            // Kiểm tra nếu tất cả các ô đều trống, hiển thị danh sách gốc.
            if (string.IsNullOrEmpty(idText) && string.IsNullOrEmpty(nameText) &&
                string.IsNullOrEmpty(genderText) && string.IsNullOrEmpty(phoneText))
            {
                dtgvEmployee.DataSource = null;
                dtgvEmployee.DataSource = ListEmployee.Instance.ListEmployees; // Sử dụng danh sách gốc.
                return;
            }

            // Lọc danh sách dựa trên các điều kiện nhập vào.
            var filteredList = ListEmployee.Instance.ListEmployees
                .Where(emp =>
                    (!string.IsNullOrEmpty(idText) && emp.Id.ToString().Contains(idText)) ||
                    (!string.IsNullOrEmpty(nameText) && emp.Name.Contains(nameText, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(genderText) && emp.Sex.Equals(genderText, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(phoneText) && emp.Phone.ToString().Contains(phoneText))
                ).ToList();

            // Cập nhật DataGridView với danh sách đã lọc.
            dtgvEmployee.DataSource = null;
            dtgvEmployee.DataSource = filteredList;
        }

        // Sự kiện khi văn bản trong ô tìm kiếm thay đổi (không sử dụng trong mã hiện tại).
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
