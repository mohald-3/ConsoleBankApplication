using ConsoleBankApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Interfaces
{
    public interface IAccountRepository
    {
        BankAccount GetByAccountNumber(string accountNumber);
        void Add(BankAccount account);
        void Remove(BankAccount account);
    }
}
