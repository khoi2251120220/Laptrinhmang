using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    // Class ListEmployee để quản lý danh sách các nhân viên.
    public class ListEmployee
    {
        // Biến static để đảm bảo chỉ có một thể hiện (singleton) của ListEmployee.
        private static ListEmployee instance;

        // Danh sách chứa các đối tượng Employee.
        private List<Employee> listEmployees;

        // Property để truy cập và thay đổi danh sách nhân viên.
        public List<Employee> ListEmployees { get => listEmployees; set => listEmployees = value; }

        // Singleton pattern: đảm bảo chỉ có một thể hiện của ListEmployee được tạo.
        public static ListEmployee Instance
        {
            get
            {
                // Nếu instance chưa được khởi tạo, tạo mới nó.
                if (instance == null)
                    instance = new ListEmployee();
                return instance; // Trả về instance của ListEmployee.
            }
            set => instance = value; // Cho phép thay đổi instance (không phổ biến trong Singleton).
        }

        // Constructor riêng tư để ngăn chặn việc khởi tạo trực tiếp ngoài lớp này.
        private ListEmployee()
        {
            // Khởi tạo danh sách các nhân viên với một số dữ liệu mẫu.
            listEmployees = new List<Employee>();

            // Thêm các nhân viên vào danh sách.
            listEmployees.Add(new Employee(1, " Nguyễn Thái Dương", "Nam", new DateTime(2004, 5, 1), "Hà Nội", 123456789));
            listEmployees.Add(new Employee(2, " Nguyễn A", "Nữ", new DateTime(2003, 1, 12), "Hà Nội", 235127894));
            listEmployees.Add(new Employee(3, " Nguyễn B", "Nữ", new DateTime(2003, 2, 3), "Đà Nẵng", 1223344552));
            listEmployees.Add(new Employee(4, " Nguyễn C", "Nam", new DateTime(2002, 4, 20), "Hải Phòng", 034348201));
            listEmployees.Add(new Employee(5, " Nguyễn D", "Nam", new DateTime(2004, 5, 13), "Nghệ An", 11111111));
            listEmployees.Add(new Employee(6, " Nguyễn E", "Nam", new DateTime(2000, 2, 8), "Sài Gòn", 222222222));
            listEmployees.Add(new Employee(7, " Nguyễn F", "Nữ", new DateTime(2004, 9, 3), "Phú Quốc", 333333333));
            listEmployees.Add(new Employee(8, " Nguyễn G", "Nữ", new DateTime(2004, 12, 25), "Đăk Lăk", 444444444));
        }
    }
}
