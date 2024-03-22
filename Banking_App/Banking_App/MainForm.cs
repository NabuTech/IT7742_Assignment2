using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            ManageCustomers manageCustomersForm = new ManageCustomers();
            manageCustomersForm.Show();
        }

    }
}
