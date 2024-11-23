using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Infrastructure.Repositories
{
    public class AccountRepository : IRepository<BankAccount>
    {
        private readonly List<BankAccount> _accounts = new List<BankAccount>();

        public void Add(BankAccount account)
        {
            _accounts.Add(account);
        }

        public BankAccount GetById(string id)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == id);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _accounts;
        }

        public void Update(BankAccount account)
        {
            var existingAccount = GetById(account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount = account;
            }
        }

        public void Delete(string id)
        {
            var account = GetById(id);
            if (account != null)
            {
                _accounts.Remove(account);
            }
        }
    }
}
