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
    public class Repository<TEntity> : IUserRepository<TEntity>
        where TEntity : class
    {
        //private readonly IDbContext _dbContext;
        //private readonly IDbSet<TEntity> _dbSet = new TemplateContext();
        private readonly TemplateContext _dbSet = new TemplateContext();



        //public Repository()
        //{
        //    //var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SteamSkinContext>>()
        //    //    as ContextManager<SteamSkinContext>;

        //    //_dbContext = contextManager.GetContext();
        //    //_dbSet = _dbContext.Set<TEntity>();
        //}

        public void Add(TEntity entity)
        {
            _dbSet.Set<TEntity>().Add(entity);
            _dbSet.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _dbSet.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbSet.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
