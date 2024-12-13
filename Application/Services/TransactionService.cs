using System;
using System.Collections.Generic;
using ConsoleBankApplication.Core.Models; // Ensure you're using the correct namespace for Transaction
using ConsoleBankApplication.Core.Interfaces;

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

        account.Deposit(amount); // Use the Deposit method to modify the balance

        var transaction = new Transaction(accountNumber, amount, Transaction.TransactionType.Deposit);
        _transactionRepository.Add(transaction);
        return true;
    }

    /// <summary>
    /// Processes a withdrawal transaction.
    /// </summary>
    public bool Withdraw(string accountNumber, decimal amount)
    {
        var account = _accountRepository.GetByAccountNumber(accountNumber);
        if (account == null || amount <= 0 || !account.Withdraw(amount))  // Use Withdraw method
            return false;

        var transaction = new Transaction(accountNumber, amount, Transaction.TransactionType.Withdrawal);
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

        if (fromAccount == null || toAccount == null || amount <= 0 || !fromAccount.Withdraw(amount)) // Use Withdraw method
            return false;

        toAccount.Deposit(amount); // Use Deposit method for the destination account

        var transaction = new Transaction(fromAccountNumber, amount, Transaction.TransactionType.Transfer)
        {
            // Setting RelatedAccountNumber for transfer transactions
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
