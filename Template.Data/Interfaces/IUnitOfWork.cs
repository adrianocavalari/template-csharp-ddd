using System;
using System.Data.Entity;

namespace Template.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext();
        void BeginTransaction();
        void Commit();
    }
}
