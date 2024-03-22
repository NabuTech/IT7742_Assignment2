using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Banking_App
{
    public enum AccountType
    {
        Everyday,
        Investment,
        Omni
    }

    public class AccountController
    {
        private List<Customer> customers;
        private Dictionary<int, Account> accounts;

        public AccountController()
        {
            customers = new List<Customer>();
            accounts = new Dictionary<int, Account>();
        }


        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomer(int customerNumber)
        {
            return customers.FirstOrDefault(c => c.CustomerNumber == customerNumber);
        }

        public void UpdateCustomer(int customerNumber, Customer updatedCustomer)
        {
            Customer customer = customers.FirstOrDefault(c => c.CustomerNumber == customerNumber);
            if (customer != null)
            {
                // Update customer properties
                customer.Name = updatedCustomer.Name;
                customer.ContactDetails = updatedCustomer.ContactDetails;
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }


        public void EditCustomer(int customerNumber, string newName, string newContactDetails)
        {
            Customer customer = customers.Find(c => c.CustomerNumber == customerNumber);
            if (customer != null)
            {
                customer.Name = newName;
                customer.ContactDetails = newContactDetails;
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public void DeleteCustomer(int customerNumber)
        {
            Customer customer = customers.Find(c => c.CustomerNumber == customerNumber);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }
    
        public void CreateAccount(int customerId, int accountId, AccountType type)
        {
            Account account;
            switch (type)
            {
                case AccountType.Everyday:
                    account = new EverydayAccount(accountId);
                    break;
                // Add cases for other account types (Investment, Omni) as needed
                default:
                    throw new ArgumentException("Invalid account type.");
            }

            accounts.Add(accountId, account);
        }

        // Deposit
        public void Deposit(int accountId, decimal amount)
        {
            if (accounts.ContainsKey(accountId))
            {
                accounts[accountId].Deposit(amount);
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        // Withdraw
        public string Withdraw(int accountId, decimal amount)
        {
            if (accounts.ContainsKey(accountId))
            {
                return accounts[accountId].Withdraw(amount);
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        // Get Account Information
        public string GetAccountInformation(int accountId)
        {
            if (accounts.ContainsKey(accountId))
            {
                return accounts[accountId].GetAccountInformation();
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }
        }

        

        internal void UpdateCustomer(int selectedIndex, object customer)
        {
            throw new NotImplementedException();
        }

        internal void AddCustomer(object customer)
        {
            throw new NotImplementedException();
        }

        
    }
}
