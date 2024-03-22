using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    public abstract class Account
    {
        public int UniqueId { get; protected set; }
        public decimal Balance { get; protected set; }  
        public decimal InterestRate { get; protected set; }
        public decimal OverdraftLimit { get; protected set; }
        public decimal FeeForFailedWithdrawals { get; protected set; }

        public abstract void Deposit (decimal amount);
        public abstract string Withdraw (decimal amount);
        public abstract void CalculateInterest ();
        public abstract string GetAccountInformation();

    }

  
}
