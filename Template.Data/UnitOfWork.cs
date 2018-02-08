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

        public TRepository Repository<TRepository>()
            where TRepository : class
        {
            if (repositories.Keys.Contains(typeof(TRepository)))
                return repositories[typeof(TRepository)];

            var repo = (TRepository)Activator.CreateInstance(typeof(TRepository), _context);
            repositories.Add(typeof(TRepository), repo);
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
