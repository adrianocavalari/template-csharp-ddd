using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
    }
}
