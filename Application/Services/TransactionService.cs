using ConsoleBankApplication.Application;
using ConsoleBankApplication.Application.Services;
using ConsoleBankApplication.Application.Utilities;
using ConsoleBankApplication.Core;
using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using ConsoleBankApplication.Core.Models.Accounts;
using ConsoleBankApplication.Infrastructure;
using ConsoleBankApplication.Infrastructure.Encryption;









public class TransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    /// <summary>
    /// Processes a deposit transaction.
    /// </summary>
    public bool Deposit(string accountNumber, decimal amount)
    {
        var account = _accountRepository.GetByAccountNumber(accountNumber);
        if (account == null || amount <= 0)
            return false;

        account.Balance += amount;

        var transaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            AccountNumber = accountNumber,
            Amount = amount,
            TransactionType = TransactionType.Deposit,
            TransactionDate = DateTime.UtcNow
        };

        _transactionRepository.Add(transaction);
        return true;
    }

    /// <summary>
    /// Processes a withdrawal transaction.
    /// </summary>
    public bool Withdraw(string accountNumber, decimal amount)
    {
        var account = _accountRepository.GetByAccountNumber(accountNumber);
        if (account == null || amount <= 0 || account.Balance < amount)
            return false;

        account.Balance -= amount;

        var transaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            AccountNumber = accountNumber,
            Amount = amount,
            TransactionType = TransactionType.Withdrawal,
            TransactionDate = DateTime.UtcNow
        };

        _transactionRepository.Add(transaction);
        return true;
    }

    /// <summary>
    /// Processes a transfer transaction between two accounts.
    /// </summary>
    public bool Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
    {
        var fromAccount = _accountRepository.GetByAccountNumber(fromAccountNumber);
        var toAccount = _accountRepository.GetByAccountNumber(toAccountNumber);

        if (fromAccount == null || toAccount == null || amount <= 0 || fromAccount.Balance < amount)
            return false;

        fromAccount.Balance -= amount;
        toAccount.Balance += amount;

        var transaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            AccountNumber = fromAccountNumber,
            Amount = amount,
            TransactionType = TransactionType.Transfer,
            TransactionDate = DateTime.UtcNow,
            RelatedAccountNumber = toAccountNumber
        };

        _transactionRepository.Add(transaction);
        return true;
    }

    /// <summary>
    /// Gets the transaction history for a specific account.
    /// </summary>
    public IEnumerable<Transaction> GetTransactionHistory(string accountNumber)
    {
        return _transactionRepository.GetTransactionsByAccountNumber(accountNumber);
    }
}
