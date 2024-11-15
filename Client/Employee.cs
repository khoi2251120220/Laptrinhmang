using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    // Lớp Employee đại diện cho thông tin của một nhân viên.
    public class Employee
    {
        // Các trường dữ liệu riêng tư cho nhân viên.
        private int id;
        private string name;
        private DateTime birthday;
        private string address;
        private string sex;
        private int phone;

        // Các thuộc tính công khai để truy cập và thay đổi giá trị của các trường dữ liệu.
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Address { get => address; set => address = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Phone { get => phone; set => phone = value; }

        // Constructor có tham số để khởi tạo một nhân viên với các giá trị cụ thể.
        public Employee(int id, string name, string sex, DateTime birthday, string address, int phone)
        {
            this.Id = id;          // Gán giá trị ID cho nhân viên.
            this.Name = name;      // Gán tên cho nhân viên.
            this.Sex = sex;        // Gán giới tính cho nhân viên.
            this.Birthday = birthday; // Gán ngày sinh cho nhân viên.
            this.Address = address;  // Gán địa chỉ cho nhân viên.
            this.Phone = phone;    // Gán số điện thoại cho nhân viên.
        }

        // Constructor không tham số, dùng để tạo đối tượng nhân viên mặc định.
        public Employee()
        {
        }
    }
}
