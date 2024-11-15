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
    public partial class FormShowInfoEmployee : Form
    {
        // Biến để lưu trữ đối tượng AuctionClient, giúp kết nối với dịch vụ từ phía server.
        private AuctionClient _client;

        // Constructor của form, nhận đối tượng AuctionClient làm tham số.
        public FormShowInfoEmployee(AuctionClient client)
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện.
            _client = client; // Gán giá trị AuctionClient cho biến thành viên.
        }

        // Phương thức dùng để tải thông tin nhân viên và hiển thị vào các TextBox.
        void LoadInfo()
        {
            // Gán các giá trị từ đối tượng NewEmploy vào các TextBox tương ứng.
            txbId.Text = Const.NewEmploy.Id.ToString();
            txbName.Text = Const.NewEmploy.Name;
            txbAddress.Text = Const.NewEmploy.Address;
            txbSex.Text = Const.NewEmploy.Sex;
            txbPhone.Text = Const.NewEmploy.Phone.ToString();
            txbBirthday.Text = Const.NewEmploy.Birthday.ToString("dd/MM/yyyy");
        }

        // Sự kiện xảy ra khi form được tải.
        private void FormShowInfoEmployee_Load(object sender, EventArgs e)
        {
            // Gọi phương thức LoadInfo để tải và hiển thị thông tin nhân viên.
            LoadInfo();
        }

        // Sự kiện khi nhấn vào button2 (Chuyển sang form QLND).
        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng form QLND và hiển thị nó.
            QLND qLNDForm = new QLND(_client);
            qLNDForm.Show(); // Hiển thị form QLND.
            this.Close(); // Đóng form hiện tại.
        }

        // Sự kiện khi nhóm (group box) được chọn. (Hiện tại không thực hiện gì).
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
