using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Template.Data.Interfaces;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;

namespace Template.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private DbContextTransaction _transaction;
        private readonly Dictionary<Type, dynamic> repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            repositories = new Dictionary<Type, dynamic>();
        }

        public IRepository<T> Repository<T>()
            where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;

            IRepository<T> repo = new Repository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this._transaction == null)
                this._transaction = this._context.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            try
            {
                this._context.SaveChanges();
                if (this._transaction != null)
                    this._transaction.Commit();
            }
            catch
            {
                if (this._transaction != null)
                    this._transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            this._transaction.Rollback();
        }

        public void Dispose()
        {
            if (this._transaction != null)
                this._transaction.Dispose();

            if (this._context != null)
                this._context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
