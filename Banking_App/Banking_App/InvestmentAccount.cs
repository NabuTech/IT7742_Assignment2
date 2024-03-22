using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(int id, decimal interestRate, decimal feeForFailedWithdrawals)
        {
            UniqueId = id;
            Balance = 0;
            InterestRate = interestRate;
            OverdraftLimit = 0;
            FeeForFailedWithdrawals = feeForFailedWithdrawals;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override string Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return $"Withdrawal of ${amount} successful.";
            }
            else
            {
                return "Insufficient funds.";
            }
        }

        public override void CalculateInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Balance += interest;
        }

        public override string GetAccountInformation()
        {
            return $"Investment Account {UniqueId}; Balance: ${Balance}";
        }
    }

    

}
