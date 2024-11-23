using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Models
{
    public class Transaction
    {
        public string TransactionId { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string TransactionType { get; private set; } // e.g., Deposit, Withdrawal, Transfer

        public Transaction(string accountNumber, decimal amount, string transactionType)
        {
            TransactionId = Guid.NewGuid().ToString();
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
            TransactionDate = DateTime.Now;
        }

        public string GetTransactionDetails()
        {
            return $"{TransactionDate}: {TransactionType} of {Amount:C} in account {AccountNumber}";
        }
    }

}
