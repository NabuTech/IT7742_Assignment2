using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    public class OmniAccount : Account
    {
        public OmniAccount(int id, decimal interestRate, decimal overdraftLimit, decimal feeForFailedWithdrawals)
        {
            UniqueId = id;
            Balance = 0;
            InterestRate = interestRate;
            OverdraftLimit = overdraftLimit;
            FeeForFailedWithdrawals = feeForFailedWithdrawals;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override string Withdraw(decimal amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                return $"Withdrawal of ${amount} successful.";
            }
            else
            {
                return "Exceeds overdraft limit.";
            }
        }

        public override void CalculateInterest()
        {
            if (Balance > 1000)
            {
                decimal interest = (Balance - 1000) * InterestRate / 100;
                Balance += interest;
            }
        }

        public override string GetAccountInformation()
        {
            return $"Omni Account {UniqueId}; Balance: ${Balance}";
        }
    }
}
