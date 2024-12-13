using ConsoleBankApplication.Application.Services;
using ConsoleBankApplication.Core.Models.Accounts;
using ConsoleBankApplication.Core.Models;
using ConsoleBankApplication.Infrastructure.Repositories;
using System;
using ConsoleBankApplication.Application.Utilities;

//using ConsoleBankApplication.Application;
//using ConsoleBankApplication.Application.Services;
//using ConsoleBankApplication.Application.Utilities;
//using ConsoleBankApplication.Core;
//using ConsoleBankApplication.Core.Interfaces;
//using ConsoleBankApplication.Core.Models;
//using ConsoleBankApplication.Core.Models.Accounts;
//using ConsoleBankApplication.Infrastructure;
//using ConsoleBankApplication.Infrastructure.Encryption;
//using ConsoleBankApplication.Infrastructure.Repositories;
//using ConsoleBankApplication.Tests;

namespace BankConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var accountRepository = new AccountRepository();

            var initializer = new AppInitializer(userRepository, accountRepository);
            initializer.InitializeData();

            try
            {
                // Main application logic here
                Console.WriteLine("Welcome to the BankApp!");
                // TODO: Add menu and bank logic
            }
            finally
            {
                initializer.SaveData();
            }
        }
    }
        //    // Initialize services
        //    var userService = new UserService(); // Manages user-related operations
        //    var bankService = new BankService(); // Manages account-related operations
        //    var transactionService = new TransactionService(); // Manages transactions

        //    bool exit = false;

        //    while (!exit)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Welcome to the Bank Application");
        //        Console.WriteLine("---------------------------------");
        //        Console.WriteLine("1. Create New User");
        //        Console.WriteLine("2. Create New Account");
        //        Console.WriteLine("3. View Accounts");
        //        Console.WriteLine("4. Make a Transaction");
        //        Console.WriteLine("5. View Transaction History");
        //        Console.WriteLine("6. Exit");
        //        Console.Write("Enter your choice: ");

        //        var input = Console.ReadLine();

        //        switch (input)
        //        {
        //            case "1":
        //                CreateNewUser(userService);
        //                break;

        //            case "2":
        //                CreateNewAccount(bankService);
        //                break;

        //            case "3":
        //                ViewAccounts(bankService);
        //                break;

        //            case "4":
        //                MakeTransaction(transactionService, bankService);
        //                break;

        //            case "5":
        //                ViewTransactionHistory(transactionService);
        //                break;

        //            case "6":
        //                exit = true;
        //                Console.WriteLine("Thank you for using the Bank Application. Goodbye!");
        //                break;

        //            default:
        //                Console.WriteLine("Invalid choice. Please try again.");
        //                break;
        //        }

        //        if (!exit)
        //        {
        //            Console.WriteLine("\nPress any key to return to the menu...");
        //            Console.ReadKey();
        //        }
        //    }
    //}

    //private static void CreateNewUser(UserService userService)
    //    {
    //        Console.Clear();
    //        Console.WriteLine("Create New User");
    //        Console.WriteLine("----------------");
    //        Console.Write("Enter Full Name: ");
    //        var name = Console.ReadLine();
    //        Console.Write("Enter Email: ");
    //        var email = Console.ReadLine();

    //        var user = userService.CreateUser(name, email);
    //        Console.WriteLine($"User created successfully! User ID: {user.Id}");
    //    }

    //    private static void CreateNewAccount(BankService bankService)
    //    {
    //        Console.Clear();
    //        Console.WriteLine("Create New Account");
    //        Console.WriteLine("-------------------");
    //        Console.Write("Enter Account Holder ID: ");
    //        var userId = Console.ReadLine();
    //        Console.Write("Enter Initial Balance: ");
    //        if (decimal.TryParse(Console.ReadLine(), out var initialBalance))
    //        {
    //            Console.WriteLine("Select Account Type:");
    //            Console.WriteLine("1. Saving Account");
    //            Console.WriteLine("2. Investment Account");
    //            Console.WriteLine("3. Private Account");
    //            Console.Write("Enter your choice: ");
    //            var accountType = Console.ReadLine();

    //            BankAccount account = accountType switch
    //            {
    //                "1" => bankService.CreateAccount<SavingAccount>(userId, initialBalance),
    //                "2" => bankService.CreateAccount<InvestmentAccount>(userId, initialBalance),
    //                "3" => bankService.CreateAccount<PrivateAccount>(userId, initialBalance),
    //                _ => null
    //            };

    //            if (account != null)
    //            {
    //                Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}");
    //            }
    //            else
    //            {
    //                Console.WriteLine("Failed to create account. Please check your inputs.");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid balance input.");
    //        }
    //    }

    //    private static void ViewAccounts(BankService bankService)
    //    {
    //        Console.Clear();
    //        Console.WriteLine("View Accounts");
    //        Console.WriteLine("-------------");
    //        Console.Write("Enter Account Holder ID: ");
    //        var userId = Console.ReadLine();

    //        var accounts = bankService.GetAccountsByUser(userId);

    //        if (accounts.Count > 0)
    //        {
    //            Console.WriteLine("\nAccounts:");
    //            foreach (var account in accounts)
    //            {
    //                Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance:C}, Type: {account.GetType().Name}");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("No accounts found for the specified user.");
    //        }
    //    }

    //    private static void MakeTransaction(TransactionService transactionService, BankService bankService)
    //    {
    //        Console.Clear();
    //        Console.WriteLine("Make a Transaction");
    //        Console.WriteLine("-------------------");
    //        Console.Write("Enter Source Account Number: ");
    //        var sourceAccount = Console.ReadLine();
    //        Console.Write("Enter Destination Account Number: ");
    //        var destinationAccount = Console.ReadLine();
    //        Console.Write("Enter Amount: ");
    //        if (decimal.TryParse(Console.ReadLine(), out var amount))
    //        {
    //            var result = transactionService.MakeTransaction(sourceAccount, destinationAccount, amount);
    //            Console.WriteLine(result ? "Transaction successful!" : "Transaction failed. Please check the account details and balance.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid amount input.");
    //        }
    //    }

    //    private static void ViewTransactionHistory(TransactionService transactionService)
    //    {
    //        Console.Clear();
    //        Console.WriteLine("View Transaction History");
    //        Console.WriteLine("-------------------------");
    //        Console.Write("Enter Account Number: ");
    //        var accountNumber = Console.ReadLine();

    //        var transactions = transactionService.GetTransactionHistory(accountNumber);

    //        if (transactions.Count > 0)
    //        {
    //            Console.WriteLine("\nTransaction History:");
    //            foreach (var transaction in transactions)
    //            {
    //                Console.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount:C}, From: {transaction.SourceAccount}, To: {transaction.DestinationAccount}");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("No transactions found for the specified account.");
    //        }
    //    }
    //}
}
