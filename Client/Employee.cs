using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Employee
    {

        private int id;
        private string name;
        private DateTime birthday;
        private string address;
        private string sex;
        private int phone;


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Address { get => address; set => address = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Phone { get => phone; set => phone = value; }


        public Employee(int id, string name, string sex, DateTime birthday, string address, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Birthday = birthday;
            this.Address = address;
            this.Phone = phone;
        }
        public Employee()
        {

        }
    }
}
