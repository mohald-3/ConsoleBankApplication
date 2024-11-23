using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Models
{
    public class User
    {
        public string UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string firstName, string lastName, string email, string passwordHash)
        {
            UserId = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsValidPassword(string password)
        {
            // This is just a placeholder for actual password verification logic (e.g., hash comparison).
            return password == PasswordHash;
        }
    }

}
