using System;
using System.Collections.Generic;
using System.Linq;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models.Common;
using ProductMS.Models.Interfaces;
using ProductMS.Services.Abstractions;

namespace ProductMS.Services
{
    public class BaseModelService<TModel, TEntity> : IModelService<TModel> where TModel : class where TEntity : class
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly IModelTransformer<TModel, TEntity> _transformer;
        public BaseModelService(IEntityRepository<TEntity> repository, IModelTransformer<TModel, TEntity> transformer)
        {
            _repository = repository;
            _transformer = transformer;
        }

        public virtual OperationResult Delete(object id)
        {
            var result = _repository.Delete(id);
            return new OperationResult()
            {
                IsSuccess = result
            };
        }

        public virtual OperationResult<List<TModel>> GetAll()
        {
            var data = _repository.GetAll();
            var models = data.Select(x => _transformer.ToModel(x)).ToList();
            return OperationResult.From(models);
        }

        public virtual OperationResult<TModel> GetById(object id)
        {
            var data = _repository.GetById(id);
            return OperationResult.From(_transformer.ToModel(data));
        }

        public virtual OperationResult<TModel> Insert(TModel t)
        {
            if (t is IChangeTrackable)
            {
                ((IChangeTrackable)t).CreatedDate = DateTime.Now;
                ((IChangeTrackable)t).UpdatedDate = DateTime.Now;
            }
            if (t is IPreservable)
            {
                ((IPreservable)t).IsDeleted = false;
            }
            
            var data = _repository.Insert(_transformer.ToProviderData(t));
            return OperationResult.From(_transformer.ToModel(data));
        }

        public virtual OperationResult<TModel> Update(TModel t)
        {
            if (t is IChangeTrackable)
            {
                ((IChangeTrackable)t).UpdatedDate = DateTime.Now;
            }
            var data = _repository.Update(_transformer.ToProviderData(t));
            return OperationResult.From(_transformer.ToModel(data));
        }
    }
}
