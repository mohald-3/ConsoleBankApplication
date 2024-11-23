using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Application.Services
{
    public class BankService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<BankAccount> _accountRepository;

        public BankService(IRepository<User> userRepository, IRepository<BankAccount> accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public User RegisterUser(string firstName, string lastName, string email, string passwordHash)
        {
            var user = new User(firstName, lastName, email, passwordHash);
            _userRepository.Add(user);
            return user;
        }

        public BankAccount CreateAccount(Type accountType, string accountHolderId, decimal initialBalance)
        {
            if (!typeof(BankAccount).IsAssignableFrom(accountType))
                throw new ArgumentException("Type must be a subclass of BankAccount.");

            var accountNumber = GenerateAccountNumber();
            var account = Activator.CreateInstance(accountType, accountNumber, accountHolderId, initialBalance) as BankAccount;

            if (account != null)
            {
                _accountRepository.Add(account);
            }

            return account;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            var account = _accountRepository.GetById(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                _accountRepository.Update(account);
            }
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            var account = _accountRepository.GetById(accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
                _accountRepository.Update(account);
            }
        }

        public BankAccount GetAccountDetails(string accountNumber)
        {
            return _accountRepository.GetById(accountNumber);
        }

        public User GetUserDetails(string userId)
        {
            return _userRepository.GetById(userId);
        }

        private string GenerateAccountNumber()
        {
            // Example: Generate a unique account number (you could use GUID or a specific format)
            return Guid.NewGuid().ToString();
        }
    }

}
