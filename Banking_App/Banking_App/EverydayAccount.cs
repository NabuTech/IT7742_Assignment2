using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    public class EverydayAccount : Account
    {
        public EverydayAccount(int id)
        {
            UniqueId = id;
            Balance = 0;
            InterestRate = 0;
            OverdraftLimit = 0;
            FeeForFailedWithdrawals = 0;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override string Withdraw(decimal amount)
        {
            if (Balance > 0)
            {
                Balance -= amount;
                return $"Withdrawal of ${amount} succesful";
            }
            else
                return "Insufficient Funds";
        }

        public override void CalculateInterest()
        {
            // No interest for Everyday Account
        }

        public override string GetAccountInformation()
        {
            return $"Everyday Account {UniqueId}; Balance: ${Balance}";
        }
    }
}
