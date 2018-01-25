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
        private Dictionary<Type, dynamic> repositories = new Dictionary<Type, dynamic>();

        //private bool _disposed;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbContext DbContext()
        {
            return _context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this._transaction == null)
            {
                if (this._transaction != null)
                    this._transaction.Dispose();

                this._transaction = this._context.Database.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                this._context.SaveChanges();
                this._transaction.Commit();
            }
            catch
            {
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
            {
                this._transaction.Dispose();
                this._transaction = null;
            }

            if (this._context != null)
            {
                //this._transaction.Database.Connection.Close();
                this._transaction.Dispose();
                this._transaction = null;
            }
        }


        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //    _disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
