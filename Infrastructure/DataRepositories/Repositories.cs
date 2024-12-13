using ConsoleBankApplication.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleBankApplication.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly List<T> _entities = new List<T>();
        private readonly string _filePath;

        protected BaseRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        // Mark these methods as virtual
        public virtual T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public void Delete(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public void LoadData()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                var entities = JsonSerializer.Deserialize<List<T>>(jsonData);
                if (entities != null)
                {
                    _entities.Clear();
                    _entities.AddRange(entities);
                }
            }
        }

        public void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(_entities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
