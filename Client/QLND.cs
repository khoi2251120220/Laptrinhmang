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
    public partial class QLND : Form
    {
        int index = -1;

        private AuctionClient _client;
        public QLND(AuctionClient client)
        {
            InitializeComponent();
            _client = client;
        }
        void LoadListEmployee()
        {
            dtgvEmployee.Rows.Clear();
            foreach (var item in ListEmployee.Instance.ListEmployees)
            {
                dtgvEmployee.Rows.Add(item.Id, item.Name, item.Address, item.Birthday.ToShortDateString(), item.Sex, item.Phone);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
                _client.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLND_Load(object sender, EventArgs e)
        {
            LoadListEmployee();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Const.NewEmploy = null;

            FormAddNewEmployee f = new FormAddNewEmployee(_client);
            f.FormClosed += F_FormClosed;
            f.ShowDialog();
        }
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListEmployee.Instance.ListEmployees.Add(Const.NewEmploy);
            LoadListEmployee();
        }

        private void dtgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
                return;
            Const.NewEmploy = new Employee();
            Const.NewEmploy.Id = ListEmployee.Instance.ListEmployees[index].Id;
            Const.NewEmploy.Birthday = ListEmployee.Instance.ListEmployees[index].Birthday;
            Const.NewEmploy.Name = ListEmployee.Instance.ListEmployees[index].Name;
            Const.NewEmploy.Sex = ListEmployee.Instance.ListEmployees[index].Sex;
            Const.NewEmploy.Address = ListEmployee.Instance.ListEmployees[index].Address;
            Const.NewEmploy.Phone = ListEmployee.Instance.ListEmployees[index].Phone;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
            {
                MessageBox.Show("hãy chọn 1 đối tượng");
                return;
            }
            ListEmployee.Instance.ListEmployees.RemoveAt(index);
            LoadListEmployee();
        }


        private void buton_xem_Click(object sender, EventArgs e)
        {
            if (index < 0 || index >= ListEmployee.Instance.ListEmployees.Count)
            {
                MessageBox.Show("hãy chọn 1 đối tượng");
                return;
            }
            FormShowInfoEmployee formShowInfoEmployee = new FormShowInfoEmployee(_client);
            formShowInfoEmployee.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepage_admin homepage_Admin = new Homepage_admin(_client);
            homepage_Admin.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string idText = txtId.Text.Trim();
            string nameText = txtName.Text.Trim();
            string genderText = txtSex.Text.Trim();
            string phoneText = txtPhone.Text.Trim();

            // Kiểm tra nếu tất cả các ô đều trống, hiển thị danh sách gốc
            if (string.IsNullOrEmpty(idText) && string.IsNullOrEmpty(nameText) &&
                string.IsNullOrEmpty(genderText) && string.IsNullOrEmpty(phoneText))
            {
                dtgvEmployee.DataSource = null;
                dtgvEmployee.DataSource = ListEmployee.Instance.ListEmployees; // Sử dụng danh sách gốc
                return;
            }

            // Lọc danh sách dựa trên bất kỳ dữ liệu nào có sẵn
            var filteredList = ListEmployee.Instance.ListEmployees
                .Where(emp =>
                    (!string.IsNullOrEmpty(idText) && emp.Id.ToString().Contains(idText)) ||
                    (!string.IsNullOrEmpty(nameText) && emp.Name.Contains(nameText, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(genderText) && emp.Sex.Equals(genderText, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(phoneText) && emp.Phone.ToString().Contains(phoneText))
                ).ToList();

            // Cập nhật DataGridView với danh sách đã lọc
            dtgvEmployee.DataSource = null;
            dtgvEmployee.DataSource = filteredList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
