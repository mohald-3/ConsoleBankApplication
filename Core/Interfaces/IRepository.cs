using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication.Core.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(string id);
    }

}
