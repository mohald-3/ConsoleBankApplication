using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using ConsoleBankApplication.Infrastructure.Utilities;
using System.Linq;

namespace ConsoleBankApplication.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository<BankAccount>, IRepository<BankAccount>
    {
        public AccountRepository() : base(AppConstants.AccountsFilePath) { }

        public override BankAccount GetById(string id)
        {
            return _entities.FirstOrDefault(a => a.AccountNumber == id);
        }

        public override void Update(BankAccount account)
        {
            var index = _entities.FindIndex(a => a.AccountNumber == account.AccountNumber);
            if (index != -1)
            {
                _entities[index] = account;
            }
        }
    }
}
