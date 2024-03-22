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
    public partial class ManageCustomers : Form
    {

        private AccountController accountController;
        private object listCustomers;

        public ManageCustomers()
        {
            InitializeComponent();
            accountController = new AccountController();
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            UpdatelistBoxCustomer();
        }

        private void UpdatelistBoxCustomer()
        {
            listBoxCustomers.Items.Clear(); // Clear existing items

            // Populate listBoxCustomers with customer names
            foreach (var customer in accountController.GetCustomers())
            {
                listBoxCustomers.Items.Add(customer.Name);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addCustomerForm = new AddCustomerForm())
            {
                if (addCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    // Add the new customer
                    accountController.AddCustomer(addCustomerForm.Customer);
                    UpdatelistBoxCustomer(); ;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer to edit.");
            }
            else
            {
                // Open a form for editing the selected customer
                using (var editCustomerForm = new EditCustomerForm())
                {
                    editCustomerForm.Customer = (Customer)accountController.GetCustomer(listBoxCustomers.SelectedIndex);
                    if (editCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the customer
                        accountController.UpdateCustomer(listBoxCustomers.SelectedIndex, editCustomerForm.Customer);
                        UpdatelistBoxCustomer();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                // Ensure a customer is selected
                if (listBoxCustomers.SelectedIndex != -1)
                {
                    // Delete the selected customer
                    accountController.DeleteCustomer(listBoxCustomers.SelectedIndex);
                    UpdatelistBoxCustomer();
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.");
                }
            }
        }
    }
}
