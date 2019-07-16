using ProductMS.DataAccess.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services
{
    public class BaseEntityService<T> : IEntityService<T> where T : class
    {
        readonly IEntityRepository<T> _repository;
        public BaseEntityService(IEntityRepository<T> repository)
        {
            _repository = repository;
        }
        public bool Delete(object id)
        {
            return _repository.Delete(id);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public T Insert(T t)
        {
            return _repository.Insert(t);
        }

        public T Update(T t)
        {
            return _repository.Update(t);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
