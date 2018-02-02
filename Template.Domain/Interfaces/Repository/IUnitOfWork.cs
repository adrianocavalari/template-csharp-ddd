using System;

namespace Template.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void Commit();
    }
}
