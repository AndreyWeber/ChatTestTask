using System;
using System.Data.Entity;

namespace ChatTestTask.Data.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        protected BaseRepository(DbContext dbContext)
        {
            if (dbContext != null)
            {
                DbContext = dbContext;
                DbSet = DbContext.Set<T>();
            }
            else
            {
                throw new ArgumentNullException("dbContext", "DbContext must be not null");
            }
        }
    }
}