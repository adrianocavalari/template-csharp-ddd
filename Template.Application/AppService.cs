using System.Collections.Generic;
using Template.Application.Interface;
using Template.Domain.Interfaces.Repository;

namespace Template.Application
{
    public class AppService<TEntity> : IAppService<TEntity>
        where TEntity : class
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<TEntity> _repository;

        public AppService(IUnitOfWork uow, IRepository<TEntity> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        protected void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
