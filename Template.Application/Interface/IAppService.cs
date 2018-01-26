using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Application.Interface
{
    public interface IAppService<TEntity, TEntityViewModel> : IDisposable
        where TEntity : class
        where TEntityViewModel : class
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntityViewModel> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);

        Task AddAsync(TEntityViewModel entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntityViewModel>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
