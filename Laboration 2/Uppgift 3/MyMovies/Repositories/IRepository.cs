using System.Collections.Generic;

namespace MyMovies.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Find(int id);
        IEnumerable<T> Get();
        void Edit(T entity);
        void Remove(T entity);
    }
}