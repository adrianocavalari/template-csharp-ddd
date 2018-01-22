using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Context;
using Template.Domain.Interfaces.Repository;

namespace Template.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        //public Repository()
        //{
        //    //var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SteamSkinContext>>()
        //    //    as ContextManager<SteamSkinContext>;

        //    //_dbContext = contextManager.GetContext();
        //    //_dbSet = _dbContext.Set<TEntity>();
        //}

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
