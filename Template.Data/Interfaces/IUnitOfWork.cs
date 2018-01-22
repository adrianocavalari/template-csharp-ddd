using System.Data.Entity;

namespace Template.Interfaces.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
