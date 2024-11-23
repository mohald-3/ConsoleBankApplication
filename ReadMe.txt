BankApp/
│
├── Core/
│   ├── Models/
│   │   ├── User.cs               // Represents the customer
│   │   ├── BankAccount.cs        // Base class for accounts
│   │   ├── Transaction.cs        // Represents transactions
│   ├── Interfaces/
│       ├── IRepository.cs        // Generic repository interface
│       ├── IAuthenticationService.cs // Authentication contract
│
├── Infrastructure/
│   ├── Repositories/
│   │   ├── UserRepository.cs     // Manages user data
│   │   ├── AccountRepository.cs  // Manages account data
│   ├── Encryption/
│       ├── EncryptionHelper.cs   // Handles encryption/decryption
│
├── Application/
│   ├── Services/
│   │   ├── BankService.cs        // Core bank logic
│   │   ├── TransactionService.cs // Handles transaction processing
│   │   ├── AuthenticationService.cs // Manages login/logout
│   ├── Utilities/
│       ├── ValidationUtils.cs    // Reusable input validation methods
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
