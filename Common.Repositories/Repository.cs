using Common.Interfaces;
using Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IList<T> _collection;

        public Repository(IList<T> collection)
        {
            _collection = collection ?? throw new ArgumentNullException(
                    string.Format(
                    "Repository<{0}>: collection == null",
                    typeof(T).Name));
        }

        public void Add(T item)
        {
            if (item == null || _collection.Contains(item))
                return;

            _collection.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _collection;
        }

        public T GetById(int id)
        {
            return _collection.First(e => e.Id == id);
        }
    }
}
