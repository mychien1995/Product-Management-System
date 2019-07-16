using ProductMS.Models.Interfaces;
using ProductMS.Services.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMS.Services
{
    public class BaseModelService<TModel> : IModelService<TModel> where TModel : class 
    {
        protected IEntityService<IModelTransformable<TModel>> _entityService;
        protected IModelTransformer<TModel> _modelTransformer;
        public BaseModelService(IEntityService<IModelTransformable<TModel>> entityService, IModelTransformer<TModel> modelTransformer)
        {
            _entityService = entityService;
            _modelTransformer = modelTransformer;
        }

        public bool Delete(object id)
        {
            return _entityService.Delete(id);
        }

        public List<TModel> GetAll()
        {
            var entityList = _entityService.GetAll();
            return entityList.Select(x => _modelTransformer.ToModel(x)).ToList();
        }

        public TModel GetById(object id)
        {
            var entity = _entityService.GetById(id);
            if (entity == null) return null;
            return _modelTransformer.ToModel(entity);
        }

        public TModel Insert(TModel t)
        {
            var entity = _modelTransformer.ToEntity(t);
            var newEntity = _entityService.Insert(entity);
            return _modelTransformer.ToModel(newEntity);
        }

        public void SaveChanges()
        {
            _entityService.SaveChanges();
        }

        public TModel Update(TModel t)
        {
            var entity = _modelTransformer.ToEntity(t);
            var newEntity = _entityService.Update(entity);
            return _modelTransformer.ToModel(newEntity);
        }
    }
}
