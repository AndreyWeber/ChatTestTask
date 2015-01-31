using System;

namespace ChatTestTask.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}