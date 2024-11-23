using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(string id)
        {
            return _users.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.UserId);
            if (existingUser != null)
            {
                existingUser = user;
            }
        }

        public void Delete(string id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }

}
