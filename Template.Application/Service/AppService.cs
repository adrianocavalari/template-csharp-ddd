using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Data.Interfaces;
using Template.Domain.Interfaces.Repository;

namespace Template.Application.Service
{
    public class AppService<TEntity, TEntityViewModel> : IAppService<TEntity, TEntityViewModel>
        where TEntity : class
        where TEntityViewModel : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public AppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityViewModel>>(_repository.GetAll());
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public async Task AddAsync(TEntityViewModel entity)
        {
            await _repository.AddAsync(Mapper.Map<TEntityViewModel, TEntity>(entity));
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntityViewModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityViewModel>>(await _repository.GetAllAsync());
        }

        public async Task UpdateAsync(TEntity entity)
        {
           await  _repository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
