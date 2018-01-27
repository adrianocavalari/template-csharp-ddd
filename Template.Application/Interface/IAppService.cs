using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Application.Interface
{
    public interface IAppService<TEntityViewModel> : IDisposable
        where TEntityViewModel : class
    {
        void Add(TEntityViewModel entity);
        TEntityViewModel GetById(int id);
        IEnumerable<TEntityViewModel> GetAll();
        void Update(TEntityViewModel entity);
        void Remove(TEntityViewModel entity);

        Task<TEntityViewModel> GetByIdAsync(int id);
        Task<IEnumerable<TEntityViewModel>> GetAllAsync();
    }
}
