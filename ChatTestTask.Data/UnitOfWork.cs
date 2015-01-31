using System;

using ChatTestTask.Data.Entities;
using ChatTestTask.Data.Interfaces;
using ChatTestTask.Data.Repositories;

namespace ChatTestTask.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ChatTestTaskDbContext DbContext { get; set; }

        #region Repositories

        public GenericRepository<Chat> ChatRepository
        { 
            get
            {
                return new GenericRepository<Chat>(DbContext);
            }
        }

        public GenericRepository<ChatMessage> ChatMessageRepository
        {
            get
            {
                return new GenericRepository<ChatMessage>(DbContext);
            }
        }

        public GenericRepository<ChatUser> ChatUserRepository
        {
            get
            {
                return new GenericRepository<ChatUser>(DbContext);
            }
        }

        #endregion

        public UnitOfWork()
        {
            CreateDbContext();

        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        #region Disposing

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (DbContext != null))
            {
                DbContext.Dispose();
            }
        }

        #endregion

        #region Helpers

        protected void CreateDbContext()
        {
            DbContext = new ChatTestTaskDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion
    }
}
