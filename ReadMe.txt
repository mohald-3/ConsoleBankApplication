BankApp/
│
├── Core/
│   ├── Models/
│   │   ├── User.cs               // Represents the customer
│   │   ├── BankAccount.cs        // Base class for accounts
│   │   ├── Transaction.cs        // Represents transactions
│   │   ├── Accounts/               // Represents the customer
│   │       ├── InvestmentAccount.cs        // Base class for accounts
│   │       ├── PrivateAccount.cs        // Represents transactions
│   │       ├── SavingAccount.cs        // Represents transactions
│   ├── Interfaces/
│       ├── IRepository.cs        // Generic repository interface
│       ├── IAuthenticationService.cs // Authentication contract
│       ├── IRepository.cs 
│       ├── ITransactionRepository.cs 
│
├── Infrastructure/
│   ├── DataRepositories/
│   │   ├── Repositories.cs     // Base class for other repositories
│   │   ├── UserRepository.cs   // sub class of repositories
│   │   ├── AccountRepository.cs    // sub class of repositories
│   ├── Utilities/
│   │   ├── JsonFileHelper.cs   // Handles JSON read/write
│   │   ├── AppConstants.cs     // Centralized constants for file paths
│   ├──Encryption/
│       ├──EncryptionHelper.cs
│
├── Application/
│   ├── Services/
│   │   ├── BankService.cs        // Core bank logic
│   │   ├── TransactionService.cs // Handles transaction processing
│   │   ├── AuthenticationService.cs // Manages login/logout
│   ├── Utilities/
│       ├── ValidationUtils.cs    // Reusable input validation methods
│       ├── IDGenerator.cs          
│
├── Presentation/
│   ├── Program.cs                // Main console application entry point
│
├── Tests/
│   ├── UnitTests/
│   │   ├── ServiceTests.cs       // Tests for service layer
│   │   ├── RepositoryTests.cs    // Tests for repository logic
│
└── Data/
    ├── SeedData/
        ├── users.json            // Initial user data
        ├── accounts.json         // Initial account data
