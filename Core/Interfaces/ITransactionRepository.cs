using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Interfaces
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        IEnumerable<Transaction> GetTransactionsByAccountNumber(string accountNumber);
    }
}
