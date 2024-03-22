using System;
using System.Windows.Forms;

namespace Banking_App
{
    public partial class AddCustomerForm : Form
    {
        public Customer Customer { get; private set; }

        public AddCustomerForm()
        {
            InitializeComponent();
        }

 

        private int GenerateCustomerNumber()
        {
            // You may implement your own logic to generate customer numbers
            // For simplicity, this method just returns a random number here
            Random random = new Random();
            return random.Next(1000, 10000);
        }

     

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactDetails.Text))
            {
                MessageBox.Show("Please enter contact details.");
                return;
            }

            // Create a new customer
            Customer = new Customer
            {
                CustomerNumber = GenerateCustomerNumber(), // You may implement your own logic to generate customer numbers
                Name = txtName.Text,
                ContactDetails = txtContactDetails.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
