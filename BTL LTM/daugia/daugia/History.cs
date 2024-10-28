using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class History : Form
    {
        private Server.Database database = new Server.Database();
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            //DataTable paymentHistory = database.GetPaymentHistory(username);
            dataGridViewPaymentHistory.DataSource = paymentHistory;
        }
    }
}
