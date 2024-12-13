using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Models.Accounts
{
    public class SavingAccount : BankAccount
    {
        public decimal MinimumBalance { get; private set; }

        public SavingAccount(string accountNumber, string accountHolder, decimal initialBalance = 0, decimal minimumBalance = 100)
            : base(accountNumber, accountHolder, initialBalance)
        {
            MinimumBalance = minimumBalance;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
                throw new InvalidOperationException($"Cannot withdraw below the minimum balance of {MinimumBalance:C}.");
            return base.Withdraw(amount); // Base method still returns a bool
        }

        public override string GetAccountDetails()
        {
            return $"{base.GetAccountDetails()}, Minimum Balance: {MinimumBalance:C}";
        }
    }
}
