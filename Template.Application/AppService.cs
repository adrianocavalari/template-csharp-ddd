using System.Collections.Generic;
using Template.Application.AutoMapper;
using Template.Application.Interface;
using Template.Domain.Interfaces.Repository;

namespace Template.Application
{
    public class AppService<TEntity> : IAppService<TEntity>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public AppService(IRepository<TEntity> repository)
        {
            _repository = repository;
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
