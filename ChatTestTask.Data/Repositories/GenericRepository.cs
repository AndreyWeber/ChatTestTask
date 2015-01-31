using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using ChatTestTask.Data.Interfaces;

namespace ChatTestTask.Data.Repositories
{
    public class GenericRepository<T> : BaseRepository<T>, IRepository<T> where T : class
    {
        public GenericRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<T> GetList()
        {
            return DbSet;
        }

        public T Get(long id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public void Delete(long id)
        {
            var removingEntity = DbSet.Find(id);
            if (removingEntity != null)
            {
                DbSet.Remove(removingEntity);
            }
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}