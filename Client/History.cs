using Server.Data;
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
    public partial class History : Form
    {
        private int _id;
        public History(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void History_Load(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext();
            var paymentHistory = await dbContext.GetPaymentHistoryByUserId(_id);

            dataGridViewPaymentHistory.DataSource = paymentHistory;
        }
    }
}
