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
        public partial class EditCustomerForm : Form
        {
            public Customer Customer { get; set; }

            public EditCustomerForm()
            {
                InitializeComponent();
            }

            // When the form loads, populate the text boxes with the existing customer information
            private void EditCustomerForm_Load(object sender, EventArgs e)
            {
                txtName.Text = Customer.Name;
                txtContactDetails.Text = Customer.ContactDetails;
            }

            private void btnUpdate_Click(object sender, EventArgs e)
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

                // Update the customer with the new information
                Customer.Name = txtName.Text;
                Customer.ContactDetails = txtContactDetails.Text;

                DialogResult = DialogResult.OK;
                Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
