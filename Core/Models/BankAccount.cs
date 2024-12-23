﻿using System;

namespace ConsoleBankApplication.Core.Models
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public decimal Balance { get; protected set; }

        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            if (Balance < amount) return false; // Insufficient funds
            Balance -= amount;
            return true;
        }

        public virtual string GetAccountDetails()
        {
            return $"{AccountHolder} - {AccountNumber}: Balance: {Balance:C}";
        }
    }
}
