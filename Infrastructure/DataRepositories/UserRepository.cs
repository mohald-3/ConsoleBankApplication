using ConsoleBankApplication.Core.Interfaces;
using ConsoleBankApplication.Core.Models;
using ConsoleBankApplication.Infrastructure.Utilities;
using System.Linq;

namespace ConsoleBankApplication.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository() : base(AppConstants.UsersFilePath) { }

        public override User GetById(string id)
        {
            return _entities.FirstOrDefault(u => u.UserId == id);
        }

        public override void Update(User user)
        {
            var index = _entities.FindIndex(u => u.UserId == user.UserId);
            if (index != -1)
            {
                _entities[index] = user;
            }
        }
    }
}
