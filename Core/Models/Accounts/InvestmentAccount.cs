using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Models.Accounts
{
    public class InvestmentAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }

        public InvestmentAccount(string accountNumber, string accountHolder, decimal initialBalance = 0, decimal interestRate = 0.05m)
            : base(accountNumber, accountHolder, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void ApplyInterest()
        {
            Balance += Balance * InterestRate;
        }

        public override string GetAccountDetails()
        {
            return $"{base.GetAccountDetails()}, Interest Rate: {InterestRate:P}";
        }
    }

}
