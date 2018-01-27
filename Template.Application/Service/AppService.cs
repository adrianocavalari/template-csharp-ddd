using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Domain.Interfaces.Repository;

namespace Template.Application.Service
{
    public class AppService<TEntityViewModel, TEntity> : IAppService<TEntityViewModel>
        where TEntityViewModel : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public AppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity>();
        }

        public void Add(TEntityViewModel entity)
        {
            _repository.Add(Mapper.Map<TEntity>(entity));
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntityViewModel>>(_repository.GetAll());
        }

        public TEntityViewModel GetById(int id)
        {
            return Mapper.Map<TEntityViewModel>(_repository.GetById(id));
        }

        public void Update(TEntityViewModel entity)
        {
            _repository.Update(Mapper.Map<TEntity>(entity));
        }

        public void Remove(TEntityViewModel entity)
        {
            _repository.Remove(Mapper.Map<TEntity>(entity));
        }

        public async Task<TEntityViewModel> GetByIdAsync(int id)
        {
            return Mapper.Map<TEntityViewModel>(await _repository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<TEntityViewModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TEntityViewModel>>(await _repository.GetAllAsync());
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
