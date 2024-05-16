using System.Linq.Expressions;

namespace PizzaHutAPIWithAuth.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K key);
        public Task<T> Get(K key);
        public Task<IEnumerable<T>> Get();
        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
