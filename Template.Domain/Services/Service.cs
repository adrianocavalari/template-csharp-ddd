using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces.Repository;
using Template.Domain.Interfaces.Services;

namespace Template.Domain.Services
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _respository;

        public Service(IRepository<TEntity> respository)
        {
            _respository = respository;
        }

        public void Add(TEntity entity)
        {
            _respository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _respository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _respository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _respository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _respository.Update(entity);
        }

        public void Dispose()
        {
            _respository.Dispose();
        }
    }
}
