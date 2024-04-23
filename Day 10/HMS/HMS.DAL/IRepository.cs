using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public interface IRepository<K, T> where T : class
    {
        T Add(T entity);
        T Get(K key);
        List<T> GetAll();
        T Update(T entity);
    }
}
