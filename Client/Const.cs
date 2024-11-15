using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    // Lớp Const dùng để lưu trữ các giá trị tĩnh chung cho ứng dụng
    internal class Const
    {
        // Biến tĩnh lưu trữ thông tin nhân viên mới được tạo ra.
        public static Employee NewEmploy = null;

        // Danh sách tĩnh chứa các giá trị giới tính được sử dụng trong ứng dụng.
        public static List<string> listSex = new List<string>() { "Nam", "Nữ", "Không xác định" };
    }
}
