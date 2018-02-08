using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Template.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Query();
        IQueryable<TEntityQuery> Query<TEntityQuery>() where TEntityQuery : class;
    }
}
