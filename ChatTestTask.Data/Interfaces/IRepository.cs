using System.Linq;

namespace ChatTestTask.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetList();
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(long id);
        void Delete(T entity);
    }
}