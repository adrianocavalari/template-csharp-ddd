using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interface;
using Template.Domain.Interfaces.Services;

namespace Template.Application
{
    public class AppService<TEntity> : IAppService<TEntity>
        where TEntity : class
    {
        private readonly IAppService<TEntity> _service;

        public AppService(IAppService<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
