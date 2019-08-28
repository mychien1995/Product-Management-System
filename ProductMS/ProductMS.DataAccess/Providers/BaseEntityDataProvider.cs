using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Providers
{
    public class BaseEntityDataProvider<T, T2> : IBaseDataProvider<T> where T : class
    {
        private readonly IEntityRepository<T2> _repository;
        private readonly IModelTransformer<T, T2> _transformer;
        public BaseEntityDataProvider(IEntityRepository<T2> repository, IModelTransformer<T, T2> transformer)
        {
            _repository = repository;
            _transformer = transformer;
        }
        public bool Delete(object id)
        {
            var result = _repository.Delete(id);
            _repository.SaveChanges();
            return result;
        }

        public List<T> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Select(x => _transformer.ToModel(x)).ToList();
        }

        public T GetById(object id)
        {
            var entity = _repository.GetById(id);
            return _transformer.ToModel(entity);
        }

        public T Insert(T t)
        {
            var entity = _repository.Insert(_transformer.ToProviderData(t));
            SaveChanges();
            return _transformer.ToModel(entity);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public T Update(T t)
        {
            var entity = _repository.Update(_transformer.ToProviderData(t));
            SaveChanges();
            return _transformer.ToModel(entity);
        }
    }
}
