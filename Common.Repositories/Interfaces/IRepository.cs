using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
    }
}
