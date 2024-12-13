using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Models.Accounts
{
    public class PrivateAccount : BankAccount
    {
        public string AccountManager { get; private set; }

        public PrivateAccount(string accountNumber, string accountHolder, string accountManager, decimal initialBalance = 0)
            : base(accountNumber, accountHolder, initialBalance)
        {
            AccountManager = accountManager;
        }

        public override string GetAccountDetails()
        {
            return $"{base.GetAccountDetails()}, Account Manager: {AccountManager}";
        }
    }

}
