using System;

namespace Template.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository Repository<TRepository>() where TRepository : class;
        void Commit();
    }
}
