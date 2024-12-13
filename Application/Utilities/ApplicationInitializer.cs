using ConsoleBankApplication.Infrastructure.Utilities;
using ConsoleBankApplication.Infrastructure.Repositories;
using ConsoleBankApplication.Core.Models;

namespace ConsoleBankApplication.Application.Utilities
{
    public class AppInitializer
    {
        private readonly UserRepository _userRepository;
        private readonly AccountRepository _accountRepository;

        public AppInitializer(UserRepository userRepository, AccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Loads data into repositories from JSON files at application startup.
        /// </summary>
        public void InitializeData()
        {
            _userRepository.LoadData();
            _accountRepository.LoadData();
        }

        /// <summary>
        /// Saves repository data back to JSON files at application shutdown.
        /// </summary>
        public void SaveData()
        {
            _userRepository.SaveData();
            _accountRepository.SaveData();
        }
    }
}
