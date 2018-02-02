using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.Data.Repositories;
using Template.Domain.Interfaces.Repository;

namespace Template.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, dynamic> repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            repositories = new Dictionary<Type, dynamic>();
        }

        public IRepository<T> Repository<T>()
            where T : class
        {
            if (repositories.Keys.Contains(typeof(T)))
                return repositories[typeof(T)] as IRepository<T>;

            IRepository<T> repo = new Repository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
