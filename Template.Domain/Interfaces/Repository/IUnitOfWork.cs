using System;

namespace Template.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
    }
}
