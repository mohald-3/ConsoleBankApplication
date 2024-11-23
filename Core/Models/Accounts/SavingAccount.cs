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

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
                throw new InvalidOperationException("Cannot withdraw below minimum balance.");
            base.Withdraw(amount);
        }

        public override string GetAccountDetails()
        {
            return $"{base.GetAccountDetails()}, Minimum Balance: {MinimumBalance:C}";
        }
    }

}
